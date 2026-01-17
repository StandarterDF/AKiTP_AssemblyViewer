using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Npgsql;
using static AssemblyViewerV2.Utils.Types;

namespace AssemblyViewerV2.Utils
{
    public class SQLUtils
    {
        private static string ConnectionDB_String = Program.AppSettings.DB.ConnectionString;

        public static Utils.Types.Parts GetPart(int ID)
        {
            var result = new Utils.Types.Parts();

            using (var connection = new NpgsqlConnection(ConnectionDB_String))
            {
                var commandText = @"
                    SELECT
                        ""ID"",
                        ""ID_Assembly"",
                        ""PartNumber"",
                        ""Name"",
                        ""Information"",
                        ""isStandartPart"",
                        ""Count"",
                        ""AuthorName"",
                        ""CheckedBy"",
                        ""Department"",
                        ""Material"",
                        ""Price"",
                        ""CreationDate"",
                        ""LastCheckDate"",
                        ""GOST"",
                        ""Photo""
                    FROM
                        ""public"".""Parts""
                    WHERE
                        ""ID"" = @id;";

                using (var command = new NpgsqlCommand(commandText, connection))
                {
                    command.Parameters.AddWithValue("@id", ID);
                    connection.Open();

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            var idOrdinal = reader.GetOrdinal("ID");
                            var idAssemblyOrdinal = reader.GetOrdinal("ID_Assembly");
                            var partNumberOrdinal = reader.GetOrdinal("PartNumber");
                            var nameOrdinal = reader.GetOrdinal("Name");
                            var infoOrdinal = reader.GetOrdinal("Information");
                            var isStdPartOrdinal = reader.GetOrdinal("isStandartPart");
                            var countOrdinal = reader.GetOrdinal("Count");
                            var authorOrdinal = reader.GetOrdinal("AuthorName");
                            var checkedByOrdinal = reader.GetOrdinal("CheckedBy");
                            var deptOrdinal = reader.GetOrdinal("Department");
                            var materialOrdinal = reader.GetOrdinal("Material");
                            var priceOrdinal = reader.GetOrdinal("Price");
                            var creationDateOrdinal = reader.GetOrdinal("CreationDate");
                            var lastCheckDateOrdinal = reader.GetOrdinal("LastCheckDate");
                            var gostOrdinal = reader.GetOrdinal("GOST");
                            var photoOrdinal = reader.GetOrdinal("Photo");

                            result.ID = reader.GetInt32(idOrdinal);
                            result.ID_Assembly = reader.GetInt32(idAssemblyOrdinal);
                            result.Count = reader.GetInt32(countOrdinal);
                            result.Price = reader.GetInt32(priceOrdinal);

                            result.PartNumber = reader.IsDBNull(partNumberOrdinal) ? string.Empty : reader.GetString(partNumberOrdinal);
                            result.Name = reader.IsDBNull(nameOrdinal) ? string.Empty : reader.GetString(nameOrdinal);
                            result.Information = reader.IsDBNull(infoOrdinal) ? string.Empty : reader.GetString(infoOrdinal);
                            result.isStandartPart = reader.IsDBNull(isStdPartOrdinal) ? false : reader.GetBoolean(isStdPartOrdinal);
                            result.AuthorName = reader.IsDBNull(authorOrdinal) ? string.Empty : reader.GetString(authorOrdinal);
                            result.CheckedBy = reader.IsDBNull(checkedByOrdinal) ? string.Empty : reader.GetString(checkedByOrdinal);
                            result.Department = reader.IsDBNull(deptOrdinal) ? string.Empty : reader.GetString(deptOrdinal);
                            result.Material = reader.IsDBNull(materialOrdinal) ? string.Empty : reader.GetString(materialOrdinal);
                            result.GOST = reader.IsDBNull(gostOrdinal) ? string.Empty : reader.GetString(gostOrdinal);
                            result.Photo = reader.IsDBNull(photoOrdinal) ? Array.Empty<byte>() : (byte[])reader.GetValue(photoOrdinal);

                            result.CreationDate = reader.GetDateTime(creationDateOrdinal);
                            result.LastCheckDate = reader.GetDateTime(lastCheckDateOrdinal);
                        }
                    }
                }
            }

            return result;
        }

        public static Utils.Types.Parts[] GetParts()
        {
            var result = new List<Utils.Types.Parts>();
            using (var connection = new NpgsqlConnection(ConnectionDB_String))
            {
                var commandText = @"
            SELECT
                ""ID"",
                ""ID_Assembly"",
                ""PartNumber"",
                ""Name"",
                ""Information"",
                ""isStandartPart"",
                ""Count"",
                ""AuthorName"",
                ""CheckedBy"",
                ""Department"",
                ""Material"",
                ""Price"",
                ""CreationDate"",
                ""LastCheckDate"",
                ""GOST"",
                ""Photo""
            FROM
                ""public"".""Parts""
            ORDER BY ""ID"";";
                using (var command = new NpgsqlCommand(commandText, connection))
                {
                    connection.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var part = new Utils.Types.Parts();
                            var idOrdinal = reader.GetOrdinal("ID");
                            var idAssemblyOrdinal = reader.GetOrdinal("ID_Assembly");
                            var partNumberOrdinal = reader.GetOrdinal("PartNumber");
                            var nameOrdinal = reader.GetOrdinal("Name");
                            var infoOrdinal = reader.GetOrdinal("Information");
                            var isStdPartOrdinal = reader.GetOrdinal("isStandartPart");
                            var countOrdinal = reader.GetOrdinal("Count");
                            var authorOrdinal = reader.GetOrdinal("AuthorName");
                            var checkedByOrdinal = reader.GetOrdinal("CheckedBy");
                            var deptOrdinal = reader.GetOrdinal("Department");
                            var materialOrdinal = reader.GetOrdinal("Material");
                            var priceOrdinal = reader.GetOrdinal("Price");
                            var creationDateOrdinal = reader.GetOrdinal("CreationDate");
                            var lastCheckDateOrdinal = reader.GetOrdinal("LastCheckDate");
                            var gostOrdinal = reader.GetOrdinal("GOST");
                            var photoOrdinal = reader.GetOrdinal("Photo");

                            part.ID = reader.GetInt32(idOrdinal);
                            part.ID_Assembly = reader.GetInt32(idAssemblyOrdinal);
                            part.Count = reader.GetInt32(countOrdinal);
                            part.Price = reader.GetInt32(priceOrdinal);
                            part.PartNumber = reader.IsDBNull(partNumberOrdinal) ? string.Empty : reader.GetString(partNumberOrdinal);
                            part.Name = reader.IsDBNull(nameOrdinal) ? string.Empty : reader.GetString(nameOrdinal);
                            part.Information = reader.IsDBNull(infoOrdinal) ? string.Empty : reader.GetString(infoOrdinal);
                            part.isStandartPart = reader.IsDBNull(isStdPartOrdinal) ? false : reader.GetBoolean(isStdPartOrdinal);
                            part.AuthorName = reader.IsDBNull(authorOrdinal) ? string.Empty : reader.GetString(authorOrdinal);
                            part.CheckedBy = reader.IsDBNull(checkedByOrdinal) ? string.Empty : reader.GetString(checkedByOrdinal);
                            part.Department = reader.IsDBNull(deptOrdinal) ? string.Empty : reader.GetString(deptOrdinal);
                            part.Material = reader.IsDBNull(materialOrdinal) ? string.Empty : reader.GetString(materialOrdinal);
                            part.GOST = reader.IsDBNull(gostOrdinal) ? string.Empty : reader.GetString(gostOrdinal);
                            part.Photo = reader.IsDBNull(photoOrdinal) ? Array.Empty<byte>() : (byte[])reader.GetValue(photoOrdinal);
                            part.CreationDate = reader.GetDateTime(creationDateOrdinal);
                            part.LastCheckDate = reader.GetDateTime(lastCheckDateOrdinal);

                            result.Add(part);
                        }
                    }
                }
            }
            return result.ToArray();
        }

        public static Utils.Types.Parts[] GetParts(int AssemblyID)
        {
            var result = new List<Utils.Types.Parts>();
            using (var connection = new NpgsqlConnection(ConnectionDB_String))
            {
                var commandText = @"
            SELECT
                ""ID"",
                ""ID_Assembly"",
                ""PartNumber"",
                ""Name"",
                ""Information"",
                ""isStandartPart"",
                ""Count"",
                ""AuthorName"",
                ""CheckedBy"",
                ""Department"",
                ""Material"",
                ""Price"",
                ""CreationDate"",
                ""LastCheckDate"",
                ""GOST"",
                ""Photo""
            FROM
                ""public"".""Parts""
            WHERE
                ""ID_Assembly"" = @id
            ORDER BY ""ID"";";
                using (var command = new NpgsqlCommand(commandText, connection))
                {
                    command.Parameters.AddWithValue("@id", AssemblyID);
                    connection.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var part = new Utils.Types.Parts();
                            var idOrdinal = reader.GetOrdinal("ID");
                            var idAssemblyOrdinal = reader.GetOrdinal("ID_Assembly");
                            var partNumberOrdinal = reader.GetOrdinal("PartNumber");
                            var nameOrdinal = reader.GetOrdinal("Name");
                            var infoOrdinal = reader.GetOrdinal("Information");
                            var isStdPartOrdinal = reader.GetOrdinal("isStandartPart");
                            var countOrdinal = reader.GetOrdinal("Count");
                            var authorOrdinal = reader.GetOrdinal("AuthorName");
                            var checkedByOrdinal = reader.GetOrdinal("CheckedBy");
                            var deptOrdinal = reader.GetOrdinal("Department");
                            var materialOrdinal = reader.GetOrdinal("Material");
                            var priceOrdinal = reader.GetOrdinal("Price");
                            var creationDateOrdinal = reader.GetOrdinal("CreationDate");
                            var lastCheckDateOrdinal = reader.GetOrdinal("LastCheckDate");
                            var gostOrdinal = reader.GetOrdinal("GOST");
                            var photoOrdinal = reader.GetOrdinal("Photo");

                            part.ID = reader.GetInt32(idOrdinal);
                            part.ID_Assembly = reader.GetInt32(idAssemblyOrdinal);
                            part.Count = reader.GetInt32(countOrdinal);
                            part.Price = reader.GetInt32(priceOrdinal);
                            part.PartNumber = reader.IsDBNull(partNumberOrdinal) ? string.Empty : reader.GetString(partNumberOrdinal);
                            part.Name = reader.IsDBNull(nameOrdinal) ? string.Empty : reader.GetString(nameOrdinal);
                            part.Information = reader.IsDBNull(infoOrdinal) ? string.Empty : reader.GetString(infoOrdinal);
                            part.isStandartPart = reader.IsDBNull(isStdPartOrdinal) ? false : reader.GetBoolean(isStdPartOrdinal);
                            part.AuthorName = reader.IsDBNull(authorOrdinal) ? string.Empty : reader.GetString(authorOrdinal);
                            part.CheckedBy = reader.IsDBNull(checkedByOrdinal) ? string.Empty : reader.GetString(checkedByOrdinal);
                            part.Department = reader.IsDBNull(deptOrdinal) ? string.Empty : reader.GetString(deptOrdinal);
                            part.Material = reader.IsDBNull(materialOrdinal) ? string.Empty : reader.GetString(materialOrdinal);
                            part.GOST = reader.IsDBNull(gostOrdinal) ? string.Empty : reader.GetString(gostOrdinal);
                            part.Photo = reader.IsDBNull(photoOrdinal) ? Array.Empty<byte>() : (byte[])reader.GetValue(photoOrdinal);
                            part.CreationDate = reader.GetDateTime(creationDateOrdinal);
                            part.LastCheckDate = reader.GetDateTime(lastCheckDateOrdinal);

                            result.Add(part);
                        }
                    }
                }
            }
            return result.ToArray();
        }

        public static bool InsertPart(Parts part)
        {
            try
            {
                using (var connection = new NpgsqlConnection(ConnectionDB_String))
                {
                    const string query = @"
                INSERT INTO ""Parts"" (
                    ""ID_Assembly"", ""PartNumber"", ""Name"", ""Information"",
                    ""isStandartPart"", ""Count"", ""AuthorName"", ""CheckedBy"", ""Department"",
                    ""Material"", ""Price"", ""CreationDate"", ""LastCheckDate"", ""GOST"", ""Photo""
                ) VALUES (
                    @ID_Assembly, @PartNumber, @Name, @Information,
                    @isStandartPart, @Count, @AuthorName, @CheckedBy, @Department,
                    @Material, @Price, @CreationDate, @LastCheckDate, @GOST, @Photo
                )";

                    using (var cmd = new NpgsqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@ID_Assembly", part.ID_Assembly);
                        cmd.Parameters.AddWithValue("@PartNumber", (object)part.PartNumber ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@Name", (object)part.Name ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@Information", (object)part.Information ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@isStandartPart", part.isStandartPart);
                        cmd.Parameters.AddWithValue("@Count", part.Count);
                        cmd.Parameters.AddWithValue("@AuthorName", (object)part.AuthorName ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@CheckedBy", (object)part.CheckedBy ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@Department", (object)part.Department ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@Material", (object)part.Material ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@Price", part.Price);
                        cmd.Parameters.AddWithValue("@CreationDate", part.CreationDate);
                        cmd.Parameters.AddWithValue("@LastCheckDate", part.LastCheckDate);
                        cmd.Parameters.AddWithValue("@GOST", (object)part.GOST ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@Photo", part.Photo != null && part.Photo.Length > 0 ? (object)part.Photo : DBNull.Value);

                        connection.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public static bool UpdatePart(Parts part)
        {
            try
            {
                using (var connection = new NpgsqlConnection(ConnectionDB_String))
                {
                    const string query = @"
        UPDATE ""Parts"" SET
            ""ID_Assembly"" = @ID_Assembly,
            ""PartNumber"" = @PartNumber,
            ""Name"" = @Name,
            ""Information"" = @Information,
            ""isStandartPart"" = @isStandartPart,
            ""Count"" = @Count,
            ""AuthorName"" = @AuthorName,
            ""CheckedBy"" = @CheckedBy,
            ""Department"" = @Department,
            ""Material"" = @Material,
            ""Price"" = @Price,
            ""CreationDate"" = @CreationDate,
            ""LastCheckDate"" = @LastCheckDate,
            ""GOST"" = @GOST,
            ""Photo"" = @Photo
        WHERE ""ID"" = @ID";

                    using (var cmd = new NpgsqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@ID", part.ID);
                        cmd.Parameters.AddWithValue("@ID_Assembly", part.ID_Assembly);
                        cmd.Parameters.AddWithValue("@PartNumber", (object)part.PartNumber ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@Name", (object)part.Name ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@Information", (object)part.Information ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@isStandartPart", part.isStandartPart);
                        cmd.Parameters.AddWithValue("@Count", part.Count);
                        cmd.Parameters.AddWithValue("@AuthorName", (object)part.AuthorName ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@CheckedBy", (object)part.CheckedBy ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@Department", (object)part.Department ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@Material", (object)part.Material ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@Price", part.Price);
                        cmd.Parameters.AddWithValue("@CreationDate", part.CreationDate);
                        cmd.Parameters.AddWithValue("@LastCheckDate", part.LastCheckDate);
                        cmd.Parameters.AddWithValue("@GOST", (object)part.GOST ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@Photo", part.Photo != null && part.Photo.Length > 0 ? (object)part.Photo : DBNull.Value);

                        connection.Open();
                        int rowsAffected = cmd.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static bool DeletePart(int partID)
        {
            try
            {
                using (var connection = new NpgsqlConnection(ConnectionDB_String))
                {
                    const string query = @"DELETE FROM ""Parts"" WHERE ""ID"" = @PartID";

                    using (var cmd = new NpgsqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@PartID", partID);

                        connection.Open();
                        int rowsAffected = cmd.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static Utils.Types.Assemblies GetAssembly(int ID)
        {
            var result = new Utils.Types.Assemblies();
            using (var connection = new NpgsqlConnection(ConnectionDB_String))
            {
                var commandText = @"
            SELECT
                ""ID"",
                ""Name"",
                ""AuthorName"",
                ""Version"",
                ""CreationDate"",
                ""LastCheckDate"",
                ""Description"",
                ""Information"",
                ""Photo""
            FROM
                ""public"".""Assemblies""
            WHERE
                ""ID"" = @id;";
                using (var command = new NpgsqlCommand(commandText, connection))
                {
                    command.Parameters.AddWithValue("@id", ID);
                    connection.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            var idOrdinal = reader.GetOrdinal("ID");
                            var nameOrdinal = reader.GetOrdinal("Name");
                            var authorOrdinal = reader.GetOrdinal("AuthorName");
                            var versionOrdinal = reader.GetOrdinal("Version");
                            var creationDateOrdinal = reader.GetOrdinal("CreationDate");
                            var lastCheckDateOrdinal = reader.GetOrdinal("LastCheckDate");
                            var descriptionOrdinal = reader.GetOrdinal("Description");
                            var infoOrdinal = reader.GetOrdinal("Information");
                            var photoOrdinal = reader.GetOrdinal("Photo");

                            result.ID = reader.GetInt32(idOrdinal);
                            result.Name = reader.IsDBNull(nameOrdinal) ? string.Empty : reader.GetString(nameOrdinal);
                            result.AuthorName = reader.IsDBNull(authorOrdinal) ? string.Empty : reader.GetString(authorOrdinal);
                            result.Version = reader.IsDBNull(versionOrdinal) ? string.Empty : reader.GetString(versionOrdinal);
                            result.CreationDate = reader.GetDateTime(creationDateOrdinal);
                            result.LastCheckDate = reader.GetDateTime(lastCheckDateOrdinal);
                            result.Description = reader.IsDBNull(descriptionOrdinal) ? string.Empty : reader.GetString(descriptionOrdinal);
                            result.Information = reader.IsDBNull(infoOrdinal) ? string.Empty : reader.GetString(infoOrdinal);
                            result.Photo = reader.IsDBNull(photoOrdinal) ? Array.Empty<byte>() : (byte[])reader.GetValue(photoOrdinal);
                        }
                    }
                }
            }
            return result;
        }

        public static Utils.Types.Assemblies[] GetAssemblies()
        {
            var result = new List<Utils.Types.Assemblies>();
            using (var connection = new NpgsqlConnection(ConnectionDB_String))
            {
                var commandText = @"
            SELECT
                ""ID"",
                ""Name"",
                ""AuthorName"",
                ""Version"",
                ""CreationDate"",
                ""LastCheckDate"",
                ""Description"",
                ""Information"",
                ""Photo""
            FROM
                ""public"".""Assemblies""
            ORDER BY ""ID"";";
                using (var command = new NpgsqlCommand(commandText, connection))
                {
                    connection.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var assembly = new Utils.Types.Assemblies();
                            var idOrdinal = reader.GetOrdinal("ID");
                            var nameOrdinal = reader.GetOrdinal("Name");
                            var authorOrdinal = reader.GetOrdinal("AuthorName");
                            var versionOrdinal = reader.GetOrdinal("Version");
                            var creationDateOrdinal = reader.GetOrdinal("CreationDate");
                            var lastCheckDateOrdinal = reader.GetOrdinal("LastCheckDate");
                            var descriptionOrdinal = reader.GetOrdinal("Description");
                            var infoOrdinal = reader.GetOrdinal("Information");
                            var photoOrdinal = reader.GetOrdinal("Photo");

                            assembly.ID = reader.GetInt32(idOrdinal);
                            assembly.Name = reader.IsDBNull(nameOrdinal) ? string.Empty : reader.GetString(nameOrdinal);
                            assembly.AuthorName = reader.IsDBNull(authorOrdinal) ? string.Empty : reader.GetString(authorOrdinal);
                            assembly.Version = reader.IsDBNull(versionOrdinal) ? string.Empty : reader.GetString(versionOrdinal);
                            assembly.CreationDate = reader.GetDateTime(creationDateOrdinal);
                            assembly.LastCheckDate = reader.GetDateTime(lastCheckDateOrdinal);
                            assembly.Description = reader.IsDBNull(descriptionOrdinal) ? string.Empty : reader.GetString(descriptionOrdinal);
                            assembly.Information = reader.IsDBNull(infoOrdinal) ? string.Empty : reader.GetString(infoOrdinal);
                            assembly.Photo = reader.IsDBNull(photoOrdinal) ? Array.Empty<byte>() : (byte[])reader.GetValue(photoOrdinal);

                            result.Add(assembly);
                        }
                    }
                }
            }
            return result.ToArray();
        }

        public static bool InsertAssembly(Assemblies assembly)
        {
            try
            {
                using (var connection = new NpgsqlConnection(ConnectionDB_String))
                {
                    const string query = @"
                        INSERT INTO ""Assemblies"" (
                            ""Name"",
                            ""AuthorName"",
                            ""Version"",
                            ""CreationDate"",
                            ""LastCheckDate"",
                            ""Description"",
                            ""Information"",
                            ""Photo""
                        ) VALUES (
                            @Name,
                            @AuthorName,
                            @Version,
                            @CreationDate,
                            @LastCheckDate,
                            @Description,
                            @Information,
                            @Photo
                        ) RETURNING ""ID""";
                    using (var cmd = new NpgsqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@Name", (object)assembly.Name ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@AuthorName", (object)assembly.AuthorName ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@Version", (object)assembly.Version ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@CreationDate", assembly.CreationDate);
                        cmd.Parameters.AddWithValue("@LastCheckDate", assembly.LastCheckDate);
                        cmd.Parameters.AddWithValue("@Description", (object)assembly.Description ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@Information", (object)assembly.Information ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@Photo", assembly.Photo != null && assembly.Photo.Length > 0 ? (object)assembly.Photo : DBNull.Value);
                        connection.Open();
                        var result = cmd.ExecuteScalar();
                        if (result != null && result != DBNull.Value)
                        {
                            assembly.ID = Convert.ToInt32(result);
                            return true;
                        }
                        return false;
                    }
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static bool UpdateAssembly(Assemblies assembly)
        {
            try
            {
                using (var connection = new NpgsqlConnection(ConnectionDB_String))
                {
                    const string query = @"
                        UPDATE ""Assemblies"" SET
                            ""Name"" = @Name,
                            ""AuthorName"" = @AuthorName,
                            ""Version"" = @Version,
                            ""CreationDate"" = @CreationDate,
                            ""LastCheckDate"" = @LastCheckDate,
                            ""Description"" = @Description,
                            ""Information"" = @Information,
                            ""Photo"" = @Photo
                        WHERE ""ID"" = @ID";
                    using (var cmd = new NpgsqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@ID", assembly.ID);
                        cmd.Parameters.AddWithValue("@Name", (object)assembly.Name ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@AuthorName", (object)assembly.AuthorName ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@Version", (object)assembly.Version ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@CreationDate", assembly.CreationDate);
                        cmd.Parameters.AddWithValue("@LastCheckDate", assembly.LastCheckDate);
                        cmd.Parameters.AddWithValue("@Description", (object)assembly.Description ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@Information", (object)assembly.Information ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@Photo", assembly.Photo != null && assembly.Photo.Length > 0 ? (object)assembly.Photo : DBNull.Value);
                        connection.Open();
                        int rowsAffected = cmd.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static bool DeleteAssembly(Assemblies assembly)
        {
            try
            {
                using (var connection = new NpgsqlConnection(ConnectionDB_String))
                {
                    connection.Open();
                    using (var transaction = connection.BeginTransaction())
                    {
                        try
                        {
                            const string deletePartsQuery = @"
                        DELETE FROM ""Parts""
                        WHERE ""ID_Assembly"" = @ID";

                            using (var cmd = new NpgsqlCommand(deletePartsQuery, connection, transaction))
                            {
                                cmd.Parameters.AddWithValue("@ID", assembly.ID);
                                cmd.ExecuteNonQuery();
                            }

                            const string deleteAssemblyQuery = @"
                        DELETE FROM ""Assemblies""
                        WHERE ""ID"" = @ID";

                            using (var cmd = new NpgsqlCommand(deleteAssemblyQuery, connection, transaction))
                            {
                                cmd.Parameters.AddWithValue("@ID", assembly.ID);
                                int rowsAffected = cmd.ExecuteNonQuery();

                                transaction.Commit();
                                return rowsAffected > 0;
                            }
                        }
                        catch
                        {
                            transaction.Rollback();
                            throw;
                        }
                    }
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static bool UpdateDataGridView_MainWindow(System.Windows.Forms.DataGridView Table, int ID)
        {
            using (var connection = new NpgsqlConnection(ConnectionDB_String))
            {
                var commandText = @"
            SELECT 
                ""ID"",
                ""Name"", 
                ""AuthorName"", 
                ""Material"", 
                ""CreationDate"" 
            FROM 
                ""public"".""Parts"" 
            WHERE 
                ""ID_Assembly"" = @id;";

                var dataTable = new DataTable();

                using (var adapter = new NpgsqlDataAdapter(commandText, connection))
                {
                    adapter.SelectCommand.Parameters.AddWithValue("@id", ID);
                    adapter.Fill(dataTable);
                }

                Table.DataSource = dataTable;
            }

            return false;
        }
    }
}
