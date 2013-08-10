using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Networking.Connectivity;

namespace ExemploWinRT_DetectandoConexaoInternet
{
    /// <summary>
    /// Class que auxilia na detecção do estado da conexão com a Internet.
    /// </summary>
    public static class InternetConnectionHelper
    {
        #region Atributos e Propriedades
        /// <summary>
        /// Indica se uma conexão à Internet está disponível no momento.
        /// </summary>
        public static bool ConexaoDisponivel
        {
            get
            {
                var internetConnectionProfile = NetworkInformation.GetInternetConnectionProfile();

                // Não basta checar se InternetConnectionProfile é nulo (como muitos exemplos encontrados na Internet), porque ele nunca será nulo caso você
                // tenha algum adaptador virtual (por exemplo HyperV ou VirtualBox adapters). Portanto, precisamos checar também se o connectivity level do 
                // InternetConnectionProfile é "InternetAccess".
                return internetConnectionProfile != null && internetConnectionProfile.GetNetworkConnectivityLevel().Equals(Windows.Networking.Connectivity.NetworkConnectivityLevel.InternetAccess);
            }
        }
        #endregion

        #region Eventos
        /// <summary>
        /// Simples forwarding do evento NetworkStatusChanged da classe NetworkInformation.
        /// </summary>
        public static event NetworkStatusChangedEventHandler ConexaoDisponivelChanged
        {
            add { NetworkInformation.NetworkStatusChanged += value; }
            remove { NetworkInformation.NetworkStatusChanged -= value; }
        }
        #endregion
    }
}
