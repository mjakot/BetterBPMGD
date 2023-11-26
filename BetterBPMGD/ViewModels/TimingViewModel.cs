using BetterBPMGD.Models;

namespace BetterBPMGD.ViewModels
{
    public class TimingViewModel : ViewModelBase
    {
        public Timing Timing { get; private set; }

        public int ID => Timing.Id;

        public int OffsetMSEditable
        {
            get { return Timing.OffsetMS; }
            set
            {
                Timing.OffsetMS = value;
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
                        return $"{GetFullSeconds(Timing.OffsetMS)}:{Timing.OffsetMS - GetFullSeconds(Timing.OffsetMS) * 1000}";

                    case UnitsOfTime.minute:
                        return $"{GetFullMinutes(GetFullSeconds(Timing.OffsetMS))}:{GetFullSeconds(Timing.OffsetMS)}:{Timing.OffsetMS - (GetFullMinutes(GetFullSeconds(Timing.OffsetMS)) * 60000 + GetFullSeconds(Timing.OffsetMS) * 1000)}";
                    
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

        private int GetFullSeconds(int miliseconds) => miliseconds / 1000;
        private int GetFullMinutes(int seconds) => seconds / 60;
    }
}
