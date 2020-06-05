using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic.IControllers
{
    public interface IAlertController
    {
        void AddAlert(IAlert alert);

        void EvaluateAlerts();
        void UpdateAlert(IAlert alert);
    }
}
