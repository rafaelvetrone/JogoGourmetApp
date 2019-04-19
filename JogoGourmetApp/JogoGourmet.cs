using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JogoGourmetApp
{
    public class JogoGourmet
    {
        public static readonly string TITULO = "Jogo Gourmet";
        public static readonly string TEXTO = "Pense em um prato que gosta.";
        public static readonly string ACERTOU = "Acertei de novo!";

        BaseNode root;

        public void Start()
        {
            BaseNode positivoNove = new PratoLeafNode("Lasanha");
            BaseNode negativoNove = new PratoLeafNode("Bolo de Chocolate");
            root = new PratoNode("massa", positivoNove, negativoNove);
            while (true)
            {
                DialogResult dr = MessageBox.Show(TEXTO, TITULO, MessageBoxButtons.OKCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2);
                if (dr == DialogResult.OK)
                {
                    bool acertou = root.Perguntar();
                    if (acertou)
                        dr = MessageBox.Show(ACERTOU, TITULO, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                    break;
            }
        }
    }
}