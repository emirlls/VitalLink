using VitalLink.Enums;

namespace VitalLink.Constants;

public static class LookupSeederConstants
{
    public static class BloodTypesConstants
    {
        public static readonly BloodTypeInfo APositive = new(
            "0b2374ec-0040-4d5d-b9a6-5c6333b458c8",
            nameof(APositive),
            (int)(BloodTypes.APositive));
        
        public static readonly BloodTypeInfo BPositive = new(
            "34b8f36b-8f43-449a-a86b-011ceb8c7f5b",
            nameof(BPositive),
            (int)BloodTypes.BPositive);
        
        public static readonly BloodTypeInfo AbPositive = new(
            "0b2374ec-0040-4d5d-b9a6-5c6333b458c9",
            nameof(AbPositive),
            (int)(BloodTypes.AbPositive));
        
        public static readonly BloodTypeInfo ZeroPositive = new(
            "34b8f36b-8f43-449a-a86b-011ceb8c7f6b",
            nameof(ZeroPositive),
            (int)BloodTypes.ZeroPositive);
        public static readonly BloodTypeInfo ANegative = new(
            "0b2374ec-0040-4d5d-b9a6-5c6333b458v8",
            nameof(ANegative),
            (int)(BloodTypes.ANegative));
        
        public static readonly BloodTypeInfo BNegative = new(
            "34b8f36b-8f43-449a-a86b-011ceb8b7f5b",
            nameof(BNegative),
            (int)BloodTypes.BNegative);
        public static readonly BloodTypeInfo AbNegative = new(
            "0b2374ec-0040-4d5d-b9a6-5c6333y458c8",
            nameof(AbNegative),
            (int)(BloodTypes.AbNegative));
        
        public static readonly BloodTypeInfo ZeroNegative = new(
            "34b8f36b-8f43-449a-a86b-011<eb8c7f5b",
            nameof(ZeroNegative),
            (int)BloodTypes.ZeroNegative);
    }
    
    public class BloodTypeInfo
    {
        public string Id { get; }
        public string Name { get; }
        public int Code { get; }

        public BloodTypeInfo(string id, string name, int code)
        {
            Id = id;
            Name = name;
            Code = code;
        }
    }
}