namespace TCC_Backend.Domain.Models.LastExecutions
{
    public class LastExecution : BaseEntity
    {
        public LastExecution()
        {
        }

        public LastExecution(DateTime? lastExecutionDate)
        {
            LastExecutionDate = lastExecutionDate;
        }

        public DateTime? LastExecutionDate { get; private set; }

        public void Update(DateTime? lastExecutionDate)
        {
            LastExecutionDate = lastExecutionDate;
        }
    }

}
