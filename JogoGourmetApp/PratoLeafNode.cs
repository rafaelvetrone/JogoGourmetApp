using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JogoGourmetApp
{
    public class PratoLeafNode : BaseNode
    {
        public static readonly string PRATO_QUE_PENSOU = "O prato que você pensou é {0}?";

        public static readonly string QUAL_PRATO_QUE_PENSOU = "Qual prato você pensou?";

        public static readonly string PRATO_EH_MAS_ESTE_NAO = "{0} é __________ mas {1} não.";

        public override BaseNode PratoParentNode { get; set; }

        public PratoLeafNode(string prato)
        {
            PratoNome = prato;
        }

        public override string PratoNome { get; set; }

        public override bool Perguntar()
        {
            string text = string.Format(PRATO_QUE_PENSOU, PratoNome);
            DialogResult dr = MessageBox.Show(text, JogoGourmet.TITULO, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            
            if (dr == DialogResult.Yes)
                return true;
            else
            {
                string value = string.Empty;

                dr = InputBox.Show(JogoGourmet.TITULO, QUAL_PRATO_QUE_PENSOU, ref value);

                if (dr == DialogResult.OK)
                {                    
                    BaseNode novaLeafPositiva = new PratoLeafNode(value);
                    text = string.Format(PRATO_EH_MAS_ESTE_NAO, value, this.PratoNome);
                    dr = InputBox.Show(JogoGourmet.TITULO, text, ref value);

                    PratoNode grandParentNode = (PratoNode)this.PratoParentNode;
                    BaseNode novoParent = new PratoNode(value, novaLeafPositiva, this);
                    
                    if (grandParentNode.PratoNodeNegativo == this)
                        grandParentNode.PratoNodeNegativo = novoParent;
                    else
                        grandParentNode.PratoNodePositivo = novoParent;
                }
                return false;
            }
        }
    }
}