using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JogoGourmetApp
{
    public class PratoNode:BaseNode
    { 
        public static readonly string PRATO_QUE_PENSOU = "O prato que você pensou é {0}?";

        public override string PratoNome { get; set; }            

        public override BaseNode PratoParentNode { get; set; }
        public BaseNode PratoNodePositivo { get; set; }
        public BaseNode PratoNodeNegativo { get; set; }

        public PratoNode(string prato)
        {
            PratoNome = prato;
        }   

        public PratoNode(string prato, BaseNode pratoPositivo, BaseNode pratoNegativo)
        {
            PratoNome = prato;

            PratoNodePositivo = pratoPositivo;
            PratoNodePositivo.PratoParentNode = this;

            PratoNodeNegativo = pratoNegativo;
            PratoNodeNegativo.PratoParentNode = this;
        }

        public override bool Perguntar()
        {            
            string text = string.Format(PRATO_QUE_PENSOU, PratoNome);
            DialogResult dr = MessageBox.Show(text, JogoGourmet.TITULO, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if(dr == DialogResult.Yes)
            {                
                return PratoNodePositivo.Perguntar();                
            }
            else
            {
                return PratoNodeNegativo.Perguntar();
            }
        }

    }
}
