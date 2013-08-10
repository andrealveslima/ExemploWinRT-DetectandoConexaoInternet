using GalaSoft.MvvmLight;

namespace ExemploWinRT_DetectandoConexaoInternet.ViewModel
{
    /// <summary>
    /// ViewModel contendo as propriedades e comandos a serem bindados na Main View.
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        #region Atributos e Propriedades
        /// <summary>
        /// Atalho para a propriedade de mesmo nome da classe InternetConnectionHelper. Adicionada na ViewModel para implementar suporte a change notification.
        /// </summary>
        public bool ConexaoDisponivel
        {
            get 
            { 
                return InternetConnectionHelper.ConexaoDisponivel; 
            }
        }
        #endregion

        #region Construtores
        /// <summary>
        /// Constroi uma instância de MainViewModel, realizando outras tarefas necessárias.
        /// </summary>
        public MainViewModel()
        {
            // Quando o evento ConexaoDisponivelChanged é disparado na classe InternetConnectionHelper, precisamos notificar a alteração da propriedade ConexaoDisponivel
            // para que a UI seja atualizada caso necessário.
            InternetConnectionHelper.ConexaoDisponivelChanged += (s) => GalaSoft.MvvmLight.Threading.DispatcherHelper.CheckBeginInvokeOnUI(() => RaisePropertyChanged("ConexaoDisponivel"));
        }
        #endregion
    }
}