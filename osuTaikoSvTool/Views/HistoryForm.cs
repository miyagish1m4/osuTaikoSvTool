using osuTaikoSvTool.Models;
using osuTaikoSvTool.Utils;
using osuTaikoSvTool.Utils.Helper;

namespace osuTaikoSvTool.Views
{
    public partial class HistoryForm : Form
    {
        List<UserInputData> userInputData = new List<UserInputData>();
        public HistoryForm()
        {
            InitializeComponent();
        }

        private void HistoryForm_Load(object sender, EventArgs e)
        {
            string format = "yyyy/MM/dd HH:mm:ss.fff";
            DateTime date;
            UserInputDataHelper.DeserializeUserInputData(ref userInputData);
            if (userInputData.Count > 0)
            {
                date = userInputData[0].createDate;
                lblCreateDateData.Text = date.ToString(format);
            }
            else
            {
                Common.WriteDialogMessage("W_A_EM-001");
            }
        }
    }
}
