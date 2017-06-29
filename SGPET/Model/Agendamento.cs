using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGPET.Model
{
    public class Agendamento : INotifyPropertyChanged
    {
        private string _id;
        private string _animal;
        private string _banho;
        private DateTime _chegada;
        private string _diadasemana;
        private string _fone;
        private string _observacao;
        private string _proprietario;
        private DateTime _saida;
        private double _total;

        public Agendamento()
        {
        }

        public string Id
        {
            get { return _id; }
            set
            {
                _id = value;
                NotifyOfPropertyChange("ID");
            }
        }

        public string Animal
        {
            get { return _animal; }
            set
            {
                _animal = value;
                NotifyOfPropertyChange("Animal");
            }
        }

        public string Banho
        {
            get { return _banho; }
            set
            {
                _banho = value;
                NotifyOfPropertyChange("Banho");
            }
        }

        public DateTime Chegada
        {
            get { return _chegada; }
            set
            {
                _chegada = value;
                NotifyOfPropertyChange("Chegada");
            }
        }

        public string Diadasemana
        {
            get { return _diadasemana; }
            set
            {
                _diadasemana = value;
                NotifyOfPropertyChange("Diadasemana");
            }
        }

        public string Fone
        {
            get { return _fone; }
            set
            {
                _fone = value;
                NotifyOfPropertyChange("Fone");
            }
        }

        public string Observacao
        {
            get { return _observacao; }
            set
            {
                _observacao = value;
                NotifyOfPropertyChange("Observacao");
            }
        }

        public string Proprietario
        {
            get { return _proprietario; }
            set
            {
                _proprietario = value;
                NotifyOfPropertyChange("Propretario");
            }
        }

        public DateTime Saida
        {
            get { return _saida; }
            set
            {
                _saida = value;
                NotifyOfPropertyChange("Saida");
            }
        }

        public Double Total
        {
            get { return _total; }
            set
            {
                _total = value;
                NotifyOfPropertyChange("Total");
            }
        }

        #region INotifyPropertyChanged Members
        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyOfPropertyChange(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion

    }
}
