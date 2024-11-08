using Microsoft.EntityFrameworkCore;

class ToDoDb : DbContext
{
    public ToDoDb(DbContextOptions<ToDoDb> options)
        : base(options) { }

    public DbSet<ToDo> ToDos => Set<ToDo>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ToDo>().Property(t => t.Id).ValueGeneratedOnAdd();
    }
}