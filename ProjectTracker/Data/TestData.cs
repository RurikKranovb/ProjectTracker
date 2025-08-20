using ProjectTracker.Domain.Entities;
using ProjectTracker.Domain.Entities.Base.Tags;
using ProjectTracker.Models;
using TaskStatus = ProjectTracker.Domain.Entities.Base.Tags.TaskStatus;

namespace ProjectTracker.Data
{
    public class TestData
    {
        public static List<Employee> Employees { get; } = new()
        {
            new Employee()
            {
                Id = 1,
                FirstName = "Евгений",
                SurName = "Михронов"
            },

            new Employee()
            {
                Id = 2,
                FirstName = "Ибрагим",
                SurName = "Музунбук"
            },

            new Employee()
            {
                Id = 1,
                FirstName = "Сергей",
                SurName = "Евтихов"
            },
        };

        public static IEnumerable<Project> Projects { get; } = new[]
        {
            new Project()
            {
                Id = 1, Name = "Сайт фирмы", Description = "Какое-то описание", StartDate = new DateTime(2015, 7, 20),
                Status = ProjectStatus.Completed
            },

            new Project()
            {
                Id = 2, Name = "Приложение по скорочтению", Description = "Любишь читать, учись быстрее читать",
                StartDate = new DateTime(2020, 7, 20), Status = ProjectStatus.Active
            },

            new Project()
            {
                Id = 3, Name = "Приложение по психологии", Description = "Какой у тебя психологический размер ноги?",
                StartDate = DateTime.Today, Status = ProjectStatus.Active
            },

        };

        public static IEnumerable<ProjectTask> ProjectTasks { get; } = new[]
        {
            new ProjectTask()
            {
                Id = 1,
                ParentId = 1,
                Deadline = new DateTime(2016, 7, 23),
                Name = "Оправисть заказчику",
                Description = "С богом",
                Status = TaskStatus.Completed,
                Priority = TaskPriority.High
            },

            new ProjectTask()
            {
                Id = 2,
                ParentId = 2,
                Deadline = new DateTime(2026, 7, 23),
                Name = "Реализовать тест по доброте",
                Description = "Тест по определению на сколько ты добрый",
                Status = TaskStatus.NotStarted,
                Priority = TaskPriority.Low
            },

            new ProjectTask()
            {
                Id = 3,
                ParentId = 3,
                Deadline = new DateTime(2025, 12, 23),
                Name = "Доработать режим администратора",
                Description = "Вкладки: Редактировать: изменить стиль на что-то. ",
                Status = TaskStatus.InProgress,
                Priority = TaskPriority.Medium
            },

            new ProjectTask()
            {
                Id = 4,
                ParentId = 2,
                Deadline = new DateTime(2027, 12, 23),
                Name = "Методики скорочтения",
                Description = "Сделать таблицу методик",
                Status = TaskStatus.InProgress,
                Priority = TaskPriority.High
            },


            new ProjectTask()
            {
                Id = 5,
                ParentId = 2,
                Deadline = new DateTime(2025, 11, 20),
                Name = "Методики скорочтения",
                Description = "Сделать таблицу методик",
                Status = TaskStatus.InProgress,
                Priority = TaskPriority.High
            },
        };
    }
}
