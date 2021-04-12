using System;
using System.Collections.Generic;
using System.Text;

namespace _4.BetsBusinessEntities.Wrappers
{
    public class AddBets_Wrappers
    {
        private long _betValue;
        private long _betNumber;
        private short _betColor;
        public string IdUser { get; set; }
        public long IdRoulette { get; set; }
        public long BetValue
        {
            get
            { return _betValue; }
            set
            {
                if (value > 0 && value <= 10000)
                {
                    _betValue = value;
                }
                else
                {
                    throw new ArgumentException("Valor de apuesta Invalido");
                }
            }
        }
        public long BetNumber
        {
            get
            { return _betNumber; }
            set
            {
                if (value >= 0 && value <= 36)
                {
                    _betNumber = value;
                }
                else
                {
                    throw new ArgumentException("Numero de Apuesta Invalido.");
                }
            }
        }
        public short BetColor
        {
            get
            {
                if (_betColor == 0)
                {
                    _betColor = 1;
                    IsBetColor = false;
                }
                return _betColor;
            }
            set
            {
                if (value == 1 || value == 2)
                {
                    _betColor = value;
                    IsBetColor = true;
                }
                else
                {
                    throw new ArgumentException("Color de Apuesta Invalido.");
                }
            }
        }
        public bool IsBetColor { get; set; }
    }
}
