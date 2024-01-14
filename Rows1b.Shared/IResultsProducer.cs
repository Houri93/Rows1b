
namespace Rows1b.Shared;

public interface IResultsProducer : IDisposable
{
    /// <summary>
    /// Check if all rows are sorted by "Id" property, starting from 0
    /// </summary>
    /// <returns>True if the Ids are sequential, otherwise false</returns>
    bool CheckIfIdsAreSequential();

    /// <summary>
    /// Count the number of people whose age is older than (not older or equals) the age parameter at a certain date.
    /// Finding the age usually requires a moment in time, use year, month and day parameters as the current day.
    /// </summary>
    /// <param name="age">the age to be compared to</param>
    /// <param name="year">the year component of the time of check</param>
    /// <param name="month">the month component of the time of check</param>
    /// <param name="day">the day component of the time of check</param>
    /// <returns></returns>
    int CountOlderThan(int age, int year, int month, int day);

    /// <summary>
    /// Count the number of unique initials from the name column
    /// </summary>
    /// <returns>The number of unique initials</returns>
    int CountUniqueInitials();

    /// <summary>
    /// Provide a collection of States paired with the number of people whose address belongs in that state.
    /// </summary>
    IEnumerable<KeyValuePair<string, int>> GetStatesPopulation();

    /// <summary>
    /// Get the age statistics for everyone in a moment in time
    /// </summary>
    /// <param name="min">youngest age found</param>
    /// <param name="max">oldest age found</param>
    /// <param name="avg">The average age (rounded to the nearest integer)</param>
    /// <param name="year">The year component of the moment in time</param>
    /// <param name="month">The month component of the moment in time</param>
    /// <param name="day">The day component of the moment in time</param>
    void GetAgeStats(int year, int month, int day, out int min, out int max, out int avg);
}
