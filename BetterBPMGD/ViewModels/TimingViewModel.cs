using BetterBPMGD.Models;
using BetterBPMGD.Services;
using Common;
using Timing = BetterBPMGD.Models.Timing;

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

                LevelProvider.Level.EditTiming(Timing);

                OnPropertyChanged(nameof(OffsetMSEditable));
                OnPropertyChanged(nameof(OffsetMSDisplayable));
            }
        }

        public int TimeUnitEditable
        {
            get => (int)Timing.TimeUnit;
            set
            {
                Timing.TimeUnit = (UnitsOfTime)value;

                LevelProvider.Level.EditTiming(Timing);

                OnPropertyChanged(nameof(TimeUnitEditable));
                OnPropertyChanged(nameof(OffsetMSDisplayable));
            }
        }
        
        public double BpmEditable
        {
            get => Timing.Bpm;
            set
            {
                Timing.Bpm = value;

                LevelProvider.Level.EditTiming(Timing);

                OnPropertyChanged(nameof(BpmEditable));
                OnPropertyChanged(nameof(BpmDisplayable));
            }
        }
        
        public bool SubdivideBeatsEditable
        {
            get => Timing.SubdivideBeats;
            set
            {
                Timing.SubdivideBeats = value;

                LevelProvider.Level.EditTiming(Timing);

                OnPropertyChanged(nameof(SubdivideBeatsEditable));
            }
        }
        
        public int BeatSubdivisionEditable
        {
            get => Timing.BeatSubdivision;
            set
            {
                Timing.BeatSubdivision = value;

                LevelProvider.Level.EditTiming(Timing);

                OnPropertyChanged(nameof(BeatSubdivisionEditable));
                OnPropertyChanged(nameof(BeatSubdivisionDisplayable));
            }
        }

        public int SpeedEditable
        {
            get => (int)Timing.Speed;
            set
            {
                Timing.Speed = (SpeedPortalTypes)value;

                LevelProvider.Level.EditTiming(Timing);

                OnPropertyChanged(nameof(SpeedEditable));
                OnPropertyChanged(nameof(SpeedDisplayable));
            }
        }
        
        public string ColorPatternEditable
        {
            get => Timing.ColorPattern;
            set
            {
                Timing.ColorPattern = value;

                LevelProvider.Level.EditTiming(Timing);

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
        public double BpmDisplayable => Timing.Bpm;
        public int BeatSubdivisionDisplayable => Timing.BeatSubdivision;
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

        public TimingViewModel(Timing timing) => Timing = timing;

        private ulong GetSeconds(ulong milliseconds) => milliseconds / 1000;
    }
}
