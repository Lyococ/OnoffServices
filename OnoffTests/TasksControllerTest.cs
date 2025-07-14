using Microsoft.AspNetCore.Mvc;
using Onoff.Controllers;
using Onoff.Model;

namespace OnoffTests
{
    public class TasksControllerTest
    {
        [Fact]
        public void AddTask_ValidTask_ReturnsCreatedAtAction()
        {
            // Arrange
            var controller = new TasksController(); // Asegúrate de que Tasks sea accesible
            var newTask = new TaskItem
            {
                Description = "Tarea de prueba",
                Completed = false
            };

            // Act
            var result = controller.AddTask(newTask);

            // Assert
            var createdResult = Assert.IsType<CreatedAtActionResult>(result);
            var returnedTask = Assert.IsType<TaskItem>(createdResult.Value);
            Assert.Equal("Tarea de prueba", returnedTask.Description);
            Assert.False(returnedTask.Completed);
            Assert.True(returnedTask.Id > 0);
        }
    }
}
