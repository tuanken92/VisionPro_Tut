using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Basler.Pylon;

namespace PylonLiveViewControl
{
    public partial class EnumerationComboBoxUserControl : UserControl
    {
        // Sets up the initial state.
        public EnumerationComboBoxUserControl()
        {
            InitializeComponent();
        }

        private IEnumParameter parameter = null; // The interface of the enum parameter.
        private string defaultName = "N/A";


        // Sets the parameter displayed by the user control.
        public IEnumParameter Parameter
        {
            set
            {
                // Remove the old parameter.
                if (parameter != null)
                {
                    parameter.ParameterChanged -= ParameterChanged;
                }

                // Set the new parameter.
                parameter = value;
                if (parameter != null)
                {
                    parameter.ParameterChanged += ParameterChanged;
                    labelName.Text = parameter.Advanced.GetPropertyOrDefault( AdvancedParameterAccessKey.DisplayName, parameter.Name );
                    UpdateValues();
                }
                else
                {
                    labelName.Text = defaultName;
                }
            }
        }


        // Sets the default name of the control.
        public string DefaultName
        {
            set
            {
                defaultName = value;
                if (parameter == null)
                {
                    labelName.Text = defaultName;
                }
            }
            get
            {
                return defaultName;
            }
        }


        // Provides the display name and the name of an enum value.
        private class EnumValue
        {
            public EnumValue( IEnumParameter parameter )
            {
                ValueName = parameter.GetValue();
                ValueDisplayName = parameter.GetAdvancedValueProperties( ValueName ).GetPropertyOrDefault( AdvancedParameterAccessKey.DisplayName, ValueName );
            }

            public EnumValue( IEnumParameter parameter, string valueName )
            {
                ValueName = valueName;
                ValueDisplayName = parameter.GetAdvancedValueProperties( valueName ).GetPropertyOrDefault( AdvancedParameterAccessKey.DisplayName, valueName );
            }

            public override string ToString()
            {
                return ValueDisplayName;
            }

            public string ValueName;
            public string ValueDisplayName;
        };



        // Occurs when the parameter state has changed. Updates the control.
        private void ParameterChanged( Object sender, EventArgs e )
        {
            if (InvokeRequired)
            {
                // If called from a different thread, we must use the Invoke method to marshal the call to the proper thread.
                BeginInvoke( new EventHandler<EventArgs>( ParameterChanged ), sender, e );
                return;
            }
            try
            {
                // Update the control values.
                UpdateValues();
            }
            catch
            {
                // If errors occurred, disable the control.
                SetErrorState();
            }
        }


        private void SetErrorState()
        {
            // If errors occurred, disable the control.
            comboBox.Items.Clear();
            comboBox.Items.Add( "<error>" );
            comboBox.Enabled = false;
            labelName.Enabled = false;
        }


        // Gets the current values from the node and displays them.
        private void UpdateValues()
        {
            try
            {
                if (parameter != null)
                {
                    // Reset the Combobox.
                    comboBox.Items.Clear();

                    // Set the items for the combobox and enable the combobox.
                    if (parameter.IsWritable && parameter.IsReadable)
                    {
                        string selected = parameter.GetValue();
                        foreach (string valueName in parameter)
                        {
                            EnumValue item = new EnumValue(parameter, valueName);
                            comboBox.Items.Add( item );
                            if (selected == valueName)
                            {
                                comboBox.SelectedIndex = comboBox.Items.Count - 1;
                            }
                        }

                        labelName.Enabled = true;
                        comboBox.Enabled = true;
                    }
                    // Disable the combobox, e.g. if camera is grabbing.
                    else if (parameter.IsReadable)
                    {
                        EnumValue item = new EnumValue(parameter);
                        comboBox.Items.Add( item );
                        comboBox.SelectedIndex = comboBox.Items.Count - 1;

                        labelName.Enabled = true;
                        comboBox.Enabled = false;
                    }
                    // If the parameter is not readable, disable the combobox without setting any items.
                    else
                    {
                        labelName.Enabled = false;
                        comboBox.Enabled = false;
                    }
                }
            }
            catch
            {
                // If errors occurred, disable the control.
                SetErrorState();
            }
        }


        // Handles selection changes.
        private void comboBox_SelectedIndexChanged( object sender, EventArgs e )
        {
            if (parameter != null)
            {
                try
                {
                    // If the parameter is readable and the combo box selection is ok ...
                    if (parameter.IsReadable && comboBox.SelectedIndex >= 0)
                    {
                        // ... get the displayed selected enumeration value.
                        EnumValue selectedValue = comboBox.SelectedItem as EnumValue;
                        if (parameter.CanSetValue( selectedValue.ValueName ) && selectedValue.ValueName != parameter.GetValue())
                        {
                            parameter.TrySetValue( selectedValue.ValueName );
                        }
                    }
                }
                catch
                {
                    // Ignore any errors here.
                }
            }
        }
    }
}
