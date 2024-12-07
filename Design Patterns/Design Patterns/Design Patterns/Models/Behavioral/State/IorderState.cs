namespace Design_Patterns.Models.Behavioral.State
{
    public interface IorderState
    {
         void Confirmed();
         void Canceld();
         void UnderProcessing();
         void Shiped();
         void Delivered();
         void Returned();

    }
}
