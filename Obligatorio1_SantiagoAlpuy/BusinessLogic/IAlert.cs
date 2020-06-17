namespace BusinessLogic
{
    public interface IAlert
    {
        bool Activated { get; set; }
        void Validate();
        void EvaluateAlert();
    }
}
