using UniqueWordCounter.IO;
using UniqueWordCounter.IO.Format;
using UniqueWordCounter.Service;
using UniqueWordCounter.View;

namespace UniqueWordCounter.Control
{
    internal class ProgramCtrl : IWCController, IKeyInput
    {
        readonly ISerializeRepo formatRepo;
        readonly IService workServ;
        readonly ILoader loader;
        readonly ISaver saver;
        readonly IView logger;

        public ProgramCtrl(ISerializeRepo formatRepo,
                           IService workServ,
                           ILoader loader,
                           ISaver saver,
                           IView logger)
        {
            this.formatRepo = formatRepo;
            this.workServ = workServ;
            this.loader = loader;
            this.saver = saver;
            this.logger = logger;
        }

        public bool Calc()
        {
            try
            {
                workServ.Run();
                return true;
            }
            catch (Exception exc)
            {
                logger.Report(exc.Message);
            }
            return false;
        }

        public bool GetInputString(out string input)
        {
            input = Console.ReadLine()!;
            bool check = !string.IsNullOrEmpty(input);
            if (check)
                input = input.Trim(new char[] { '*', ' ', '\'', '"' });
            return check;
        }

        public bool LoadFile(string path)
        {
            try
            {
                string format = Path.GetExtension(path);
                loader.Load(path, formatRepo.GetDeserializator(format));
                return true;
            }
            catch (ArgumentNullException exc)
            {
                logger.Report($"Invalid path of {exc.ParamName}");
            }
            catch (IOException exc)
            {
                logger.Report(exc.Message);
            }
            catch (InvalidCastException exc)
            {
                logger.Report(exc.Message);
            }
            catch (Exception exc)
            {
                logger.Report(exc.Message);
            }
            return false;
        }

        public bool SaveResult(string path)
        {
            try
            {
                string directory = Path.GetDirectoryName(path)!;
                string name = Path.GetFileName(path);
                string format = Path.GetExtension(path);
                saver.Save(directory, name, formatRepo.GetSerializator(format));
                return true;
            }
            catch (ArgumentNullException exc)
            {
                logger.Report($"Invalid path of {exc.ParamName}");
            }
            catch (IOException exc)
            {
                logger.Report(exc.Message);
            }
            catch (InvalidCastException exc)
            {
                logger.Report(exc.Message);
            }
            catch (Exception exc)
            {
                logger.Report(exc.Message);
            }
            return false;
        }

        /* To stop while iteration */
        public bool Quit() => false;

    }
}
