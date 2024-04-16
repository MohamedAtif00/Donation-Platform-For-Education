namespace Donation_Platform_For_Education.Domain.Abstarction
{
    public class ValueObjectId : ValueObject
    {
        public Guid value { get; private set; }

        protected ValueObjectId(Guid id)
        {
            value = id;
        }

        public static ValueObjectId Create(Guid id)
        {
            return new(id);
        }

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return value;
        }
    }
}
