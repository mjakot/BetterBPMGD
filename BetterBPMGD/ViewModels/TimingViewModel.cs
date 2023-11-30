using BetterBPMGD.Models;

namespace BetterBPMGD.ViewModels
{
    public class TimingViewModel : ViewModelBase
    {
        public Timing Timing { get; private set; }

        public int ID => Timing.Id;

        public ulong OffsetMSEditable
        {
            get
            {
                switch (Timing.TimeUnit)
                {
                    case UnitsOfTime.milisecond:
                        return Timing.OffsetMS;

                    case UnitsOfTime.second:
                        return Timing.OffsetMS / 1000;

                    case UnitsOfTime.minute:
                        return Timing.OffsetMS / 1000 / 60;

                    default:
                        goto case UnitsOfTime.milisecond;
                }
            }

            set
            {
                switch (Timing.TimeUnit)
                {
                    case UnitsOfTime.milisecond:
                        Timing.OffsetMS = value;
                        break;

                    case UnitsOfTime.second:
                        Timing.OffsetMS = value * 1000;
                        break;

                    case UnitsOfTime.minute:
                        Timing.OffsetMS = value * 1000 * 60;
                        break;

                    default:
                        goto case UnitsOfTime.milisecond;
                }

                OnPropertyChanged(nameof(OffsetMSEditable));
                OnPropertyChanged(nameof(OffsetMSDisplayable));
            }
        }

        public int TimeUnitEditable
        {
            get { return (int)Timing.TimeUnit; }
            set
            {
                Timing.TimeUnit = (UnitsOfTime)value;
                OnPropertyChanged(nameof(TimeUnitEditable));
                OnPropertyChanged(nameof(OffsetMSDisplayable));
            }
        }
        
        public double BpmEditable
        {
            get { return Timing.Bpm; }
            set
            {
                Timing.Bpm = value;
                OnPropertyChanged(nameof(BpmEditable));
                OnPropertyChanged(nameof(BpmDisplayable));
            }
        }
        
        public bool IncludeInBetweenBeatsEditable
        {
            get{ return Timing.IncludeInBetweenBeats; }
            set
            {
                Timing.IncludeInBetweenBeats = value;
                OnPropertyChanged(nameof(IncludeInBetweenBeatsEditable));
            }
        }
        
        public string TimeSignatureEditable
        {
            get { return Timing.TimeSignature.ToString(); }
            set
            {
                Timing.TimeSignature = Fraction.TryParse(value);
                OnPropertyChanged(nameof(TimeSignatureEditable));
                OnPropertyChanged(nameof(TimeSignatureDisplayable));
            }
        }
        
        public int SpeedEditable
        {
            get { return (int)Timing.Speed; }
            set
            {
                Timing.Speed = (SpeedPortalTypes)value;
                OnPropertyChanged(nameof(SpeedEditable));
                OnPropertyChanged(nameof(SpeedDisplayable));
            }
        }
        
        public string ColorPatternEditable
        {
            get { return Timing.ColorPattern; }
            set
            {
                Timing.ColorPattern = value;
                OnPropertyChanged(nameof(ColorPatternEditable));
            }
        }

        public string OffsetMSDisplayable
        {
            get
            {
                switch (Timing.TimeUnit)
                {
                    case UnitsOfTime.milisecond:
                        return Timing.OffsetMS.ToString();

                    case UnitsOfTime.second:
                        return $"{GetSeconds(Timing.OffsetMS)}:{Timing.OffsetMS % 1000}";

                    case UnitsOfTime.minute:
                        return $"{GetSeconds(Timing.OffsetMS) / 60}:{GetSeconds(Timing.OffsetMS) % 60}:{Timing.OffsetMS % 1000}";
                    
                    default:
                        goto case UnitsOfTime.milisecond;
                }
            }
        }
        public double BpmDisplayable { get { return Timing.Bpm; } }
        public string TimeSignatureDisplayable { get { return Timing.TimeSignature.ToString(); } }
        public string SpeedDisplayable
        {
            get
            {
                switch (Timing.Speed)
                {
                    case SpeedPortalTypes.HALFSPEED:
                        return "0.5x";

                    case SpeedPortalTypes.NORMAL:
                        return "1x";

                    case SpeedPortalTypes.DOUBLE:
                        return "2x";

                    case SpeedPortalTypes.TRIPLE:
                        return "3x";

                    case SpeedPortalTypes.QUADRUPLE:
                        return "4x";

                    default:
                        goto case SpeedPortalTypes.NORMAL;
                }
            }
        }

        public TimingViewModel(Timing timing) => this.Timing = timing;

        private ulong GetSeconds(ulong milliseconds) => milliseconds / 1000;
    }
}
