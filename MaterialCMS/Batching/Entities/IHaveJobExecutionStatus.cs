namespace MaterialCMS.Batching.Entities
{
    public interface IHaveJobExecutionStatus
    {
        JobExecutionStatus Status { get; set; }
    }
}