namespace StrategyPattern
{
    public class PaymentService
    {
        private IPaymentService _paymentService;

        public PaymentService()
        {

        }

        public PaymentService(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        public void SetPaymentService(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        public bool PayViaStrategy(PaymentOptions options)
        {
            return _paymentService.Pay(options);
        }
    }
}