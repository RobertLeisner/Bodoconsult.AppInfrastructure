using System.Data;

namespace Bodoconsult.Test.Test;

internal class TestData
{
    public static DataTable GetDataTable()
    {
        var table = new DataTable();
        table.Columns.Add("x", typeof(int));
        table.Columns.Add("y", typeof(int));
        table.Columns.Add("value", typeof(double));

        table.Rows.Add(0, 0, 1);
        table.Rows.Add(0, 1, 0.5);
        table.Rows.Add(1, 1, 1);
        table.Rows.Add(1, 0, 0.5);

        return table;
    }

    public static double[,] GetDoubleArray()
    {
        var matrix = new double[2, 2];
        matrix[0, 0] = 1;
        matrix[0, 1] = 0.5;
        matrix[1, 1] = 1;
        matrix[1, 0] = 0.5;

        return matrix;
    }
}