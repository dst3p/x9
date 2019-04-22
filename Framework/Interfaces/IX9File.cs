namespace X9.Interfaces
{
    public interface IX9File
    {
        void ProcessFileHeader();

        void ProcessCashLetterHeader();

        void ProcessBundleHeader();

        void ProcessImageViewDetail();

        void ProcessImageViewData();

        void ProcessImageViewAnalysis();

        void ProcessBundleControl();

        void ProcessCashLetterControl();

        void ProcessFileControl();
    }
}
