using System;

public class Temperature : IComparable
{
    /// <summary>
    /// Compare the temperatures
    /// </summary>
    /// <param name="obj"></param>
    /// <returns>
    /// < 0 - before
    /// = 0 - equal
    /// > 0 - after
    /// </returns>
    public int CompareTo(object obj)
    {
        if (obj == null)
            // should be after the passed object
            return 1;

        // cast object as temperature
        Temperature otherTmp = obj as Temperature;

        if (otherTmp != null)
        {
            // Now we can compare them
            if (this.temperature > otherTmp.temperature)
                return 1;
            else if (this.temperature < otherTmp.temperature)
                return -1;

            return 0;
        }
        else
        {
            // We could'nt cast the object to temperature, so is null
            throw new ArgumentException("Object is not a temperature");
        }
    }

    protected float temperature;

    public Temperature(float _tmp)
    {
        temperature = _tmp;
    }

    public override string ToString()
    {
        return temperature.ToString("0.0", System.Globalization.CultureInfo.InvariantCulture);
    }
}
