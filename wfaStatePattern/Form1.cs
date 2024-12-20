using ATMStatePattern;

namespace wfaStatePattern
{
    public partial class Form1 : Form
    {
        private AtmContext atm;
        public Form1()
        {
            InitializeComponent();
            atm = new AtmContext(1, 5000, true, 0.1);

            atm.Notify = message => lblMessage.Text = message;
            UpdateAtmStatus();
        }

        private void UpdateAtmStatus()
        {
            lblStatus.Text = $"ID: {atm.Id}\n" +
                             $"Доступные средства: {atm.CashAvailable}\n" +
                             $"Связь с банком: {(atm.IsConnected ? "Подключен" : "Отключен")}\n" +
                             $"Текущее состояние: {atm.CurrentState.GetType().Name}";
        }

        private void btnInsertPin_Click(object sender, EventArgs e)
        {
            string pin = txtPin.Text;
            atm.InsertPin(pin);
            UpdateAtmStatus();
        }

        private void BtnWithdraw_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtAmount.Text, out int amount))
            {
                atm.PerformOperation("withdraw", amount);
            }
            else
            {
                lblMessage.Text = "Введите корректную сумму для снятия.";
            }

            UpdateAtmStatus();
        }

        private void BtnReloadCash_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtReloadAmount.Text, out int amount))
            {
                atm.ReloadCash(amount);
            }
            else
            {
                lblMessage.Text = "Введите корректную сумму для пополнения.";
            }

            UpdateAtmStatus();
        }

        private void BtnFixConnection_Click(object sender, EventArgs e)
        {
            atm.FixConnection();
            UpdateAtmStatus();
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            atm.PerformOperation("exit");
            UpdateAtmStatus();
        }
    }
}
