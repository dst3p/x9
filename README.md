# X9 Framework

Framework written in C# for parsing X9.37 files. All processor classes and models are either virtual or abstract, allowing 

## Usage

```csharp
var file = "path to file";
var processor = new X9.Processor();

using (var inputStream = new System.IO.FileStream(file, System.IO.FileMode.Open))
{
    processor.Execute(inputStream);
}
```

After successful execution, the X9 file is parsed into the `FileSpec` property of the `Processor` object.

## Data Model

### XML

### JSON

```json
{
  "FileHeader": {
    "RecordType": "01",
    "SpecificationLevel": "03",
    "TestFileIndicator": "P",
    "ImmediateDesignationRoutingNumber": "",
    "ImmediateOriginRoutingNumber": "",
    "FileCreationDate": null,
    "FileCreationTime": null,
    "ResendIndicator": "N",
    "ImmediateDesignationName": null,
    "ImmediateOriginName": null,
    "FileIdModifier": "1",
    "CountryCode": null,
    "UserField": null,
    "Reserved": null
  },
  "CashLetters": [
    {
      "CashLetterHeader": {
        "RecordType": "10",
        "CollectionTypeIndicator": "03",
        "DestinationRoutingNumber": null,
        "ECEInstitutionRoutingNumber": null,
        "CashLetterCreationTime": null,
        "CashLetterRecordTypeIndicator": null
      },
      "Bundles": [
        {
          "BundleType": 2,
          "BundleHeader": { "RecordType": "20" },
          "CheckItems": [],
          "ReturnItems": [
            {
              "Return": {
                "RecordType": "31",
                "PayorBankRouting": "",
                "PayorBankRoutingNumberCheckDigit": "8",
                "OnUsReturnRecord": "",
                "ItemAmount": "",
                "ReturnReason": "A",
                "ReturnRecordAddendumCount": "06",
                "ReturnDocumentationTypeIndicator": "G",
                "ForwardBundleDate": "20170929",
                "ECEInstitutionItemSequenceNumber": "     ",
                "ExternalProcessingCode": " ",
                "ReturnNotificationIndicator": " ",
                "ReturnArchiveTypeIndicator": " ",
                "Reserved": "         ",
                "FullRoutingNumber": "",
                "AccountNumber": null,
                "CheckNumber": null
              },
              "ReturnAddendumAs": [{ "RecordType": "32" }],
              "ReturnAddendumB": { "RecordType": "33" },
              "ReturnAddendumC": { "RecordType": "34" },
              "ReturnAddendumDs": [
                { "RecordType": "35" },
                { "RecordType": "35" },
                { "RecordType": "35" },
                { "RecordType": "35" }
              ],
              "ImageViews": [
                {
                  "ImageViewDetail": { "RecordType": "50" },
                  "ImageViewData": {
                    "RecordType": "52",
                    "EceInstitutionRoutingNumber": "",
                    "BundleBusinessDate": "20171002",
                    "CycleNumber": "0 ",
                    "EceInstitutionItemSequenceNumber": "     ",
                    "SecurityOriginatorName": "                ",
                    "SecurityAuthenticatorName": "                ",
                    "SecurityKeyName": "                ",
                    "ClippingOrigin": "0",
                    "ClippingCoordinateH1": "    ",
                    "ClippingCoordinateH2": "    ",
                    "ClippingCoordinateV1": "    ",
                    "ClippingCoordinateV2": "    ",
                    "ImageReferenceKeyLength": 20,
                    "ImageReferenceKey": "",
                    "DigitalSignatureLength": 0,
                    "DigitalSignature": "",
                    "ImageDataLength": 9352,
                    "Data": "SUkqAAgAA"
                  },
                  "ImageViewAnalysis": { "RecordType": "54" }
                }
              ]
            },
            {
              "Return": {
                "RecordType": "31",
                "PayorBankRouting": "",
                "PayorBankRoutingNumberCheckDigit": "1",
                "OnUsReturnRecord": "",
                "ItemAmount": "",
                "ReturnReason": "A",
                "ReturnRecordAddendumCount": "06",
                "ReturnDocumentationTypeIndicator": "G",
                "ForwardBundleDate": "20171002",
                "ECEInstitutionItemSequenceNumber": "     ",
                "ExternalProcessingCode": "4",
                "ReturnNotificationIndicator": " ",
                "ReturnArchiveTypeIndicator": "B",
                "Reserved": "         ",
                "FullRoutingNumber": "",
                "AccountNumber": null,
                "CheckNumber": null
              },
              "ReturnAddendumAs": [{ "RecordType": "32" }],
              "ReturnAddendumB": { "RecordType": "33" },
              "ReturnAddendumC": { "RecordType": "34" },
              "ReturnAddendumDs": [
                { "RecordType": "35" },
                { "RecordType": "35" },
                { "RecordType": "35" },
                { "RecordType": "35" }
              ],
              "ImageViews": [
                {
                  "ImageViewDetail": { "RecordType": "50" },
                  "ImageViewData": {
                    "RecordType": "52",
                    "EceInstitutionRoutingNumber": "",
                    "BundleBusinessDate": "",
                    "CycleNumber": "0 ",
                    "EceInstitutionItemSequenceNumber": "     ",
                    "SecurityOriginatorName": "                ",
                    "SecurityAuthenticatorName": "                ",
                    "SecurityKeyName": "                ",
                    "ClippingOrigin": "0",
                    "ClippingCoordinateH1": "    ",
                    "ClippingCoordinateH2": "    ",
                    "ClippingCoordinateV1": "    ",
                    "ClippingCoordinateV2": "    ",
                    "ImageReferenceKeyLength": 20,
                    "ImageReferenceKey": "",
                    "DigitalSignatureLength": 0,
                    "DigitalSignature": "",
                    "ImageDataLength": 6888,
                    "Data": "SUk"
                  },
                  "ImageViewAnalysis": { "RecordType": "54" }
                }
              ]
            },
            {
              "Return": {
                "RecordType": "31",
                "PayorBankRouting": "",
                "PayorBankRoutingNumberCheckDigit": "3",
                "OnUsReturnRecord": "   ",
                "ItemAmount": "",
                "ReturnReason": "C",
                "ReturnRecordAddendumCount": "06",
                "ReturnDocumentationTypeIndicator": "G",
                "ForwardBundleDate": "20171002",
                "ECEInstitutionItemSequenceNumber": "     ",
                "ExternalProcessingCode": " ",
                "ReturnNotificationIndicator": " ",
                "ReturnArchiveTypeIndicator": " ",
                "Reserved": "         ",
                "FullRoutingNumber": "",
                "AccountNumber": null,
                "CheckNumber": null
              },
              "ReturnAddendumAs": [{ "RecordType": "32" }],
              "ReturnAddendumB": { "RecordType": "33" },
              "ReturnAddendumC": { "RecordType": "34" },
              "ReturnAddendumDs": [
                { "RecordType": "35" },
                { "RecordType": "35" },
                { "RecordType": "35" },
                { "RecordType": "35" }
              ],
              "ImageViews": [
                {
                  "ImageViewDetail": { "RecordType": "50" },
                  "ImageViewData": {
                    "RecordType": "52",
                    "EceInstitutionRoutingNumber": "",
                    "BundleBusinessDate": "20171002",
                    "CycleNumber": "0 ",
                    "EceInstitutionItemSequenceNumber": "     ",
                    "SecurityOriginatorName": "                ",
                    "SecurityAuthenticatorName": "                ",
                    "SecurityKeyName": "                ",
                    "ClippingOrigin": "0",
                    "ClippingCoordinateH1": "    ",
                    "ClippingCoordinateH2": "    ",
                    "ClippingCoordinateV1": "    ",
                    "ClippingCoordinateV2": "    ",
                    "ImageReferenceKeyLength": 20,
                    "ImageReferenceKey": "",
                    "DigitalSignatureLength": 0,
                    "DigitalSignature": "",
                    "ImageDataLength": 7877,
                    "Data": "SUkqAAgAAAAQA"
                  },
                  "ImageViewAnalysis": { "RecordType": "54" }
                }
              ]
            },
            {
              "Return": {
                "RecordType": "31",
                "PayorBankRouting": "",
                "PayorBankRoutingNumberCheckDigit": "5",
                "OnUsReturnRecord": "   ",
                "ItemAmount": "",
                "ReturnReason": "C",
                "ReturnRecordAddendumCount": "06",
                "ReturnDocumentationTypeIndicator": "G",
                "ForwardBundleDate": "20171002",
                "ECEInstitutionItemSequenceNumber": "     ",
                "ExternalProcessingCode": " ",
                "ReturnNotificationIndicator": " ",
                "ReturnArchiveTypeIndicator": " ",
                "Reserved": "         ",
                "FullRoutingNumber": "",
                "AccountNumber": null,
                "CheckNumber": null
              },
              "ReturnAddendumAs": [{ "RecordType": "32" }],
              "ReturnAddendumB": { "RecordType": "33" },
              "ReturnAddendumC": { "RecordType": "34" },
              "ReturnAddendumDs": [
                { "RecordType": "35" },
                { "RecordType": "35" },
                { "RecordType": "35" },
                { "RecordType": "35" }
              ],
              "ImageViews": [
                {
                  "ImageViewDetail": { "RecordType": "50" },
                  "ImageViewData": {
                    "RecordType": "52",
                    "EceInstitutionRoutingNumber": "",
                    "BundleBusinessDate": "20171002",
                    "CycleNumber": "0 ",
                    "EceInstitutionItemSequenceNumber": "     ",
                    "SecurityOriginatorName": "                ",
                    "SecurityAuthenticatorName": "                ",
                    "SecurityKeyName": "                ",
                    "ClippingOrigin": "0",
                    "ClippingCoordinateH1": "    ",
                    "ClippingCoordinateH2": "    ",
                    "ClippingCoordinateV1": "    ",
                    "ClippingCoordinateV2": "    ",
                    "ImageReferenceKeyLength": 20,
                    "ImageReferenceKey": "",
                    "DigitalSignatureLength": 0,
                    "DigitalSignature": "",
                    "ImageDataLength": 5068,
                    "Data": "SUkqAAg"
                  },
                  "ImageViewAnalysis": { "RecordType": "54" }
                }
              ]
            }
          ],
          "BundleControl": { "RecordType": "70" },
          "BoxSummary": { "RecordType": "75" }
        }
      ],
      "AccountTotalsDetails": [],
      "NonHitTotalsDetails": [],
      "RoutingNumberSummaries": [],
      "CashLetterControl": { "RecordType": "90" }
    }
  ],
  "FileControl": { "RecordType": "99" }
}

```
