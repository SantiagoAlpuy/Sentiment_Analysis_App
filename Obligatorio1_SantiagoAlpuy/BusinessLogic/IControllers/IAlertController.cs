namespace BusinessLogic.IControllers
{
    public interface IAlertController
    {
        void AddAlert(IAlert alert);
        void EvaluateAlerts();
        void UpdateAlert(IAlert alert);
    }
}
