using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Numerics;

namespace Calculator
{
    /*
     * List of Transport Modes
     */
    public enum TransportModes
    {
        [Display(Name = "Petrol")] petrol,
        [Display(Name = "Diesel")] deisel,
        [Display(Name = "Hybrid")] hybrid,
        [Display(Name = "Electric")] electric,
        [Display(Name = "Motorbike")] motorbike,
        [Display(Name = "Electric Bike or Scooter")] electricbike,
        [Display(Name = "Train")] train,
        [Display(Name = "Bus")] bus,
        [Display(Name = "Tram")] tram,
        [Display(Name = "Cycling")] cycling,
        [Display(Name = "Walking")] walkin

        // Average walking speed in miles per hour

    }

    public enum DistanceMeasurement
    {
        [Display(Name = "Miles")] miles,
        [Display(Name = "Kilometers")] kms

    }

    public class Calculator
    {
        public static List<double> transportModeWeighting = new List<double> { 8, 10, 6, 4, 3, 2, 3, 3, 3, 0.005, 0.005 };

        public const int distanceMin = 1;
        public const int distanceMax = 1000;

        [Range(distanceMin, distanceMax, ErrorMessage = "Invalid distance - Only Available from 1 to 1000 miles")]
        [DisplayName("Enter Your Distance to work (KMs/miles):")]
        public double distance { get; set; }

        [DisplayName("Select A Distance Measurement:")]
        public DistanceMeasurement milesOrKms { get; set; }

        public const int daysMin = 1;
        public const int daysMax = 7;

        [Range(daysMin, daysMax, ErrorMessage = "Invalid num of days - Only Available from 1 to 7 days")]
        [DisplayName("Enter the number of days you travel to work:")]
        public double numDays { get; set; }

        [DisplayName("Select A Transport mode:")]
        public TransportModes transportMode { get; set; }

        //Ensure that distance is in miles for calculation
        private double convertDistance()
        {

            return milesOrKms.Equals(DistanceMeasurement.kms) ? this.distance / 1.609344 : this.distance;
            //Code Improvement
        }

        // calculate sustainability number
        [DisplayName("Your Sustainability Weighting:")]
        public double sustainabilityWeighting
        {
            // Total =  (Transport method Weighting * distance to work (in miles) * (onsite num Days per week*2))
            get
            {
                double total = 0;



                //Improved the code by using switch statement 
                //The code was same for all the if statements so we changed this way to improve code quality
                switch (transportMode)
                {
                    case TransportModes.petrol:
                    case TransportModes.deisel:
                    case TransportModes.hybrid:
                    case TransportModes.electric:
                    case TransportModes.motorbike:
                    case TransportModes.electricbike:
                    case TransportModes.train:
                    case TransportModes.bus:
                    case TransportModes.tram:
                    case TransportModes.cycling:
                    case TransportModes.walkin:
                        total = transportModeWeighting[(int)transportMode] * convertDistance() * (this.numDays * 2);
                        break;
                }

                return total;
            }


        }
        [DisplayName("Average Daily Sustainability :")]
        public double AverageDailySustainability { get { double Value = CalculateAverageSustainability(); return Value; } }

        //New feature to calculate the average sustainability weighting
        //for a given list of transport modes.

        public double CalculateAverageSustainability()
        {
            List<TransportModes> selectedModes = new List<TransportModes>   {
                TransportModes.petrol,
            TransportModes.deisel,
            TransportModes.hybrid,
            TransportModes.electric,
            TransportModes.motorbike,
            TransportModes.electricbike,
            TransportModes.train,
            TransportModes.bus,
            TransportModes.tram,
            TransportModes.cycling,
            TransportModes.walkin
            };
            double totalWeighting = 0;

            foreach (var mode in selectedModes)
            {
                totalWeighting += this.sustainabilityWeighting / this.numDays;
            }

            return totalWeighting / selectedModes.Count;
        }

    }
}
