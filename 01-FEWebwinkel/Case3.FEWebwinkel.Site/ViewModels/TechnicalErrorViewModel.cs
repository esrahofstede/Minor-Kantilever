namespace Case3.FEWebwinkel.Site.ViewModels
{
    public class TechnicalErrorViewModel
    {
        public string Message { get; set; }

        public TechnicalErrorViewModel(string message)
        {
            Message = message;
        }
    }
}