using PortalAGR.Shared.Configurations;
using System.Text;

namespace PortalAGR.Shared.Extensions
{
    public static class PasswordExtension
    {
        /// <summary>
        /// Efetua a encriptação de um senha
        /// </summary>
        /// <param name="senha">senha a ser encriptada</param>
        /// <returns>Retorna a senha encriptada.</returns>
        public static string EncriptarSenha(string senha)
        {
            if (string.IsNullOrEmpty(senha)) return "";

            senha += ConfiguracoesCompartilhadas.SEGREDO_SENHA;
            var novaSenha = senha;
            var md5 = System.Security.Cryptography.MD5.Create();
            var data = md5.ComputeHash(Encoding.Default.GetBytes(novaSenha));
            var senhaEncriptada = new StringBuilder();

            foreach (var t in data)
                senhaEncriptada.Append(t.ToString("x2"));

            return senhaEncriptada.ToString();
        }
    }
}
