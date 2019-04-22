﻿using X9.Models;
using X9.RecordProcessors.Interface;

namespace X9.RecordProcessors
{
    public class CashLetterControlProcessor : BaseRecordProcessor<CashLetterControl>, ITypeProcessor
	{
		public string RecordType { get; set; } = "90";

		public override void Execute()
		{
			base.Execute();

			if (Parent.CurrentCashLetter == null)
			{
				throw new System.Exception("X9 file is malformed or was parsed incorrectly.");
			}

			Parent.CurrentCashLetter.CashLetterControl = Model;

			// Add the cash letter to the file spec
			Parent.FileSpec.CashLetters.Add(Parent.CurrentCashLetter);
		}

		protected override CashLetterControl PopulateModel()
		{
			return new CashLetterControl();
		}
	}
}
