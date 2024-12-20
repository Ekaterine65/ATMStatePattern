using System;

namespace ATMStatePattern
{
    public interface IAtmState
    {
        void InsertPin(AtmContext context, string pin);
        void PerformOperation(AtmContext context, string operation, int amount = 0);
        void ReloadCash(AtmContext context, int amount);
        void FixConnection(AtmContext context);
    }

    public class AtmContext
    {
        public int Id { get; set; }
        public IAtmState CurrentState { get; set; }
        public int CashAvailable { get; set; }
        public bool IsConnected { get; set; }
        public double ConnectionFailureProbability { get; set; }
        private static Random random = new Random();

        public Action<string> Notify { get; set; }

        public AtmContext(int id, int initialCash, bool isConnected, double connectionFailureProbability)
        {
            Id = id;
            CashAvailable = initialCash;
            IsConnected = isConnected;
            ConnectionFailureProbability = connectionFailureProbability;
            CurrentState = new WaitingState();
        }

        public void InsertPin(string pin) => CurrentState.InsertPin(this, pin);
        public void PerformOperation(string operation, int amount = 0)
        {
            SimulateConnectionFailure();
            CurrentState.PerformOperation(this, operation, amount);
        }
        public void ReloadCash(int amount) => CurrentState.ReloadCash(this, amount);
        public void FixConnection() => CurrentState.FixConnection(this);

        private void SimulateConnectionFailure()
        {
            if (random.NextDouble() < ConnectionFailureProbability)
            {
                IsConnected = false;
            }
        }
    }

    public class WaitingState : IAtmState
    {
        public void InsertPin(AtmContext context, string pin)
        {
            context.Notify?.Invoke("PIN-код вводится. Переход к проверке.");
            context.CurrentState = new AuthenticatingState();
            context.CurrentState.InsertPin(context, pin);
        }

        public void PerformOperation(AtmContext context, string operation, int amount = 0)
        {
            context.Notify?.Invoke("Сначала введите PIN-код.");
        }

        public void ReloadCash(AtmContext context, int amount)
        {
            context.Notify?.Invoke("Вы не можете загрузить деньги в режиме ожидания.");
        }

        public void FixConnection(AtmContext context)
        {
            context.Notify?.Invoke("Подключение в порядке, банкомат уже в режиме ожидания.");
        }
    }

    public class AuthenticatingState : IAtmState
    {
        public void InsertPin(AtmContext context, string pin)
        {
            if (pin == "1234")
            {
                context.Notify?.Invoke("PIN-код верен. Переход к выполнению операций.");
                context.CurrentState = new OperationalState();
            }
            else
            {
                context.Notify?.Invoke("Неверный PIN-код. Возврат в режим ожидания.");
                context.CurrentState = new WaitingState();
            }
        }

        public void PerformOperation(AtmContext context, string operation, int amount = 0)
        {
            context.Notify?.Invoke("Проверка PIN-кода ещё не завершена.");
        }

        public void ReloadCash(AtmContext context, int amount)
        {
            context.Notify?.Invoke("Вы не можете загрузить деньги во время проверки PIN-кода.");
        }

        public void FixConnection(AtmContext context)
        {
            context.Notify?.Invoke("Подключение в порядке, проверка PIN-кода продолжается.");
        }
    }

    public class OperationalState : IAtmState
    {
        public void InsertPin(AtmContext context, string pin)
        {
            context.Notify?.Invoke("Вы уже вошли в систему. Выполните операцию или завершите работу.");
        }

        public void PerformOperation(AtmContext context, string operation, int amount = 0)
        {
            if (!context.IsConnected)
            {
                context.Notify?.Invoke("Ошибка связи с банком. Банкомат заблокирован.");
                context.CurrentState = new BlockedState();
                return;
            }

            switch (operation.ToLower())
            {
                case "withdraw":
                    if (amount <= context.CashAvailable && amount > 0)
                    {
                        context.CashAvailable -= amount;
                        context.Notify?.Invoke($"Снято {amount}. Остаток в банкомате: {context.CashAvailable}.");

                        if (context.CashAvailable <= 0)
                        {
                            context.Notify?.Invoke("Деньги закончились. Банкомат заблокирован.");
                            context.CurrentState = new BlockedState();
                        }
                    }
                    else
                    {
                        context.Notify?.Invoke("Недостаточно средств или неверная сумма.");
                    }
                    break;
                case "exit":
                    context.Notify?.Invoke("Завершение работы. Переход в режим ожидания.");
                    context.CurrentState = new WaitingState();
                    break;
                default:
                    context.Notify?.Invoke("Неизвестная операция. Попробуйте снова.");
                    break;
            }
        }

        public void ReloadCash(AtmContext context, int amount)
        {
            context.Notify?.Invoke("Вы не можете загрузить деньги во время выполнения операций.");
        }

        public void FixConnection(AtmContext context)
        {
            context.Notify?.Invoke("Банкомат уже подключен.");
        }
    }

    public class BlockedState : IAtmState
    {
        public void InsertPin(AtmContext context, string pin)
        {
            context.Notify?.Invoke("Банкомат заблокирован. Операции невозможны.");
        }

        public void PerformOperation(AtmContext context, string operation, int amount = 0)
        {
            context.Notify?.Invoke("Банкомат заблокирован. Операции невозможны.");
        }

        public void ReloadCash(AtmContext context, int amount)
        {
            context.CashAvailable += amount;
            context.Notify?.Invoke($"Банкомат пополнен. Доступно: {context.CashAvailable}.");

            if (context.IsConnected && context.CashAvailable > 0)
            {
                context.Notify?.Invoke("Банкомат разблокирован. Переход в режим ожидания.");
                context.CurrentState = new WaitingState();
            }
        }

        public void FixConnection(AtmContext context)
        {
            context.IsConnected = true;
            context.Notify?.Invoke("Связь восстановлена.");

            if (context.CashAvailable > 0)
            {
                context.Notify?.Invoke("Банкомат разблокирован. Переход в режим ожидания.");
                context.CurrentState = new WaitingState();
            }
        }
    }
}
