namespace Pizza4Ps.PizzaService.Domain.Abstractions.Entities
{
    public interface ISoftDelete
    {
        public bool IsDeleted { get; set; }
        string? DeletedBy { get; set; }
        public DateTimeOffset? DeletedAt { get; set; }

        public void Undo()
        {
            IsDeleted = false;
            DeletedAt = null;
            DeletedBy = null;
        }
    }
}
