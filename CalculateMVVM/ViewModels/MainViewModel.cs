using CalculateMVVM.Models;
using System;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace CalculateMVVM.ViewModels
{
    class MainViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

        private string expression;

        public string Expression
        {
            get { return expression; }
            set { expression = value; OnPropertyChanged("Expression"); }
        }

        public string Result
        {
            get
            {
                string exps = Expression;

                if (Expression != null)
                {
                    if (Expression.Contains('×')) { exps = Expression.Replace('×', '*'); }

                    else if (Expression.Contains('÷')) { exps = Expression.Replace('÷', '/'); }
                }

                return Calculate.Calc(exps);
            }
        }

        public ICommand Solve
        {
            get
            {
                return new DelegateCommand((obj) => {
                    //call Result
                    OnPropertyChanged("Result"); 
                    //clear property
                    Expression = String.Empty;
                    //call Expression
                    OnPropertyChanged("Expression");
                });
            }
        }

        public ICommand BackSpace
        {
            get
            {
                return new DelegateCommand((obj) => {
                    try
                    {
                        if(Expression != null)
                            Expression = Expression.Remove(Expression.Length - 1);
                    }
                    catch (Exception) { }
                });
            }
        }

        //print 1,2,3,4,5,6,7,8,9,0,(,)
        public ICommand Print
        {
            get
            {
                return new DelegateCommand((obj) => {
                    string text = obj as string;
                    Expression = Expression + text;
                });
            }
        }
    }
}
