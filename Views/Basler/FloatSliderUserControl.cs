using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Basler.Pylon;

namespace PylonLiveViewControl
{
    // Displays a slider bar, the name of the parameter, minimum, maximum, and current value.
    public partial class FloatSliderUserControl : UserControl
    {

        // Sets up the initial state.
        public FloatSliderUserControl()
        {
            InitializeComponent();
            Reset();
        }


        private IFloatParameter parameter = null; // The interface of the float parameter.
        private string defaultName = "N/A";
        private bool sliderMoving = false;


        // Sets the parameter displayed by the user control.
        public IFloatParameter Parameter
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
                    Reset();
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
                // Update accessibility and parameter values.
                UpdateValues();
            }
            catch
            {
                // If errors occurred disable the control.
                Reset();
            }
        }




        // Deactivate the control and deregister the callback.
        private void Reset()
        {
            slider.Enabled = false;
            labelMin.Enabled = false;
            labelMax.Enabled = false;
            labelName.Enabled = false;
            labelCurrentValue.Enabled = false;
        }


        // Converts slider range to percent value.
        private int PercentToSliderValue( double percent )
        {
            return (int)((100000.0 / 100.0) * percent);
        }


        // Converts percent value to slider range.
        private double SliderToPercentValue( int sliderValue )
        {
            return (((double)sliderValue) / 100000.0) * 100.0;
        }


        // Gets the current values from the node and displays them.
        private void UpdateValues()
        {
            try
            {
                if (parameter != null)
                {
                    if (parameter.IsReadable)  // Check if the parameter is readable.
                    {
                        // Get the values.
                        double min = parameter.GetMinimum();
                        double max = parameter.GetMaximum();
                        double val = parameter.GetValue();
                        double percent = parameter.GetValuePercentOfRange();

                        // Update the slider.
                        slider.Minimum = PercentToSliderValue( 0 );
                        slider.Maximum = PercentToSliderValue( 100 );
                        slider.Value = PercentToSliderValue( percent );
                        slider.SmallChange = PercentToSliderValue( 0.05 );
                        slider.TickFrequency = PercentToSliderValue( 10 );

                        // Update the displayed values.
                        labelMin.Text = "" + min;
                        labelMax.Text = "" + max;
                        labelCurrentValue.Text = "" + val;

                        // Update the access status.
                        slider.Enabled = parameter.IsWritable;
                        labelMin.Enabled = true;
                        labelMax.Enabled = true;
                        labelName.Enabled = true;
                        labelCurrentValue.Enabled = true;

                        return;
                    }
                }
            }
            catch
            {
                // If errors occurred, disable the control.
            }
            Reset();

        }


        // Occurs when the slider position changes.
        private void slider_Scroll( object sender, EventArgs e )
        {
            if (parameter != null)
            {
                try
                {
                    if (parameter.IsWritable && !sliderMoving)
                    {
                        // Break any recursion if the value does not exactly match the slider value.
                        sliderMoving = true;

                        // Set the value.
                        parameter.SetValuePercentOfRange( SliderToPercentValue( slider.Value ) );
                    }
                }
                catch
                {
                    // Ignore any errors here.
                }
                finally
                {
                    sliderMoving = false;
                }
            }
        }
    }
}
