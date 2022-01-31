namespace FormsSnake.Model
{
    public interface ISnakeModel
    {
        /// <summary>
        /// Get length of snake
        /// </summary>
        /// <returns>Length of snake</returns>
        int GetLength();

        /// <summary>
        /// Eat an apple
        /// </summary>
        void EatAnApple();

        /// <summary>
        /// Kill the snake
        /// </summary>
        void Die();

        /// <summary>
        /// Reborn snake
        /// </summary>
        void Reborn();

        /// <summary>
        /// Checking the alive of a snake
        /// </summary>
        /// <returns>Alive status</returns>
        bool IsAlive();
    }
}
