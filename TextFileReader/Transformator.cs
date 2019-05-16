using System;
using System.IO;
using System.Linq;
using TextFileReader.Data;

namespace TextFileReader
{
    public sealed class Transformator
    {
        private BlockType _currentBlock = BlockType.None;
        private readonly Archivo _archivo = new Archivo();
        public Archivo Transform(StreamReader reader)
        {
            string line = reader.ReadLine();
            while (line != null)
            {
                string trimmedLine = line.Trim();
                bool isNotNullNorEmpty = !string.IsNullOrEmpty(trimmedLine);
                if (isNotNullNorEmpty)
                {
                    ProccessLine(trimmedLine);
                }

                line = reader.ReadLine();
            }

            _archivo.ProccesingDate = DateTime.Now;

            return _archivo;
        }
        private  void ProccessLine(string trimmedLine)
        {
            if (IsCommentOrBlockIdentifier(trimmedLine))
            {
                BlockType blockType = GetBlockIdentifier(trimmedLine);
                if (blockType != BlockType.None)
                {
                    ChangeBlock(newBlock: blockType);
                }
            }
            else
            {
                AccumulateLine(trimmedLine);
            }
        }

        private void AccumulateLine(string trimmedLine)
        {
            switch (_currentBlock)
            {
                case BlockType.Header:
                    AccumulateHeaderLine(trimmedLine);
                    break;
                case BlockType.Detail:
                    AccumulateDetailLine(trimmedLine);
                    break;
                case BlockType.Summary:
                    AccumulateSummaryLine(trimmedLine);
                    break;
                default:
                    Console.Error.WriteLine($"Line '{trimmedLine}'. Could not detect valid block identifier first.");
                    break;
            }
        }

        private void AccumulateSummaryLine(string trimmedLine)
        {
            var values = trimmedLine.Split(',').Select(column => column.Trim()).ToList();

            _archivo.EmployeeQuantity = int.Parse(values[0]);
        }

        private void AccumulateDetailLine(string trimmedLine)
        {
            var values = trimmedLine.Split(',').Select(column => column.Trim()).ToList();
            DetalleArchivo detalleArchivo = new DetalleArchivo();

            detalleArchivo.Identification = values[0];
            detalleArchivo.AccountNumber = values[1];
            detalleArchivo.Salary = decimal.Parse(values[2]);
            detalleArchivo.EmployeeCode = values[3];

            _archivo.FileDetail.Add(detalleArchivo);
        }

        private void AccumulateHeaderLine(string trimmedLine)
        {
            var values = trimmedLine.Split(',').Select(column => column.Trim()).ToList();
            _archivo.AccountNumber = values[0];
            _archivo.PaymentDate = Convert.ToDateTime(values[1]);
            _archivo.TransmissionDate = Convert.ToDateTime(values[2]);
            _archivo.RNC = values[3];
            _archivo.Roster = decimal.Parse(values[4]);

        }

        private  BlockType GetBlockIdentifier(string trimmedLine)
        {
            string possibleIdentifier = trimmedLine.Remove(0, 1).Trim();

            switch (possibleIdentifier)
            {
                case "Encabezado":
                    return BlockType.Header;
                case "Detalle":
                    return BlockType.Detail;
                case "Sumario":
                    return BlockType.Summary;
                default:
                    return BlockType.None;
            }
        }
        private void ChangeBlock(BlockType newBlock)
        {
            _currentBlock = newBlock;
        }

        private  bool IsCommentOrBlockIdentifier(string trimmedLine) => trimmedLine.StartsWith("#");

    }
}
