using System.Text;
using CryptSharp;

namespace Domain.Utils;

public static class CriptografiaUtil
{
    public static string CriptografarSenha(string senha)
    {
        string senhaCriptografada = Crypter.Blowfish.Crypt(senha);
        return senhaCriptografada;
    }

    public static bool CompararSenhas(string senhaCriptografada, string senha)
    {
        return Crypter.CheckPassword(senhaCriptografada, senha);
    }
}