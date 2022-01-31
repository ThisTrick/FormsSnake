using FormsSnake.Exception;

namespace FormsSnake.Model
{
    public class SnakeModel : ISnakeModel
    {
        private int Length { get; set; }

        private bool IsAlive { get; set; }

        public SnakeModel()
        {
            IsAlive = true;
            Length = 3;
        }

        public void Die()
        {
            if (!IsAlive)
                throw new ModelException(nameof(SnakeModel), "What is dead may never die");

            IsAlive = false;
            Length = 0;
        }

        public void EatAnApple()
        {
            Length++;
        }

        public int GetLength()
        {
            if (!IsAlive)
                throw new ModelException(nameof(SnakeModel), "What is dead has no length");

            return Length;
        }

        public bool HasAlive()
        {
            return IsAlive;
        }

        public void Reborn()
        {
            if (IsAlive)
                throw new ModelException(nameof(SnakeModel), "The living does not reborn");
            IsAlive = true;
            Length = 3;
        }
    }
}
