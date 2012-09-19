using System.Collections.Generic;

namespace VersionOne.SDK.APIClient
{
	public class OrderBy
	{
		public enum Order
		{
			Ascending,
			Descending
		}

		readonly List<Term> _terms = new List<Term>();

		public IList<Term> Terms { get {return _terms.AsReadOnly(); } }

		public void MajorSort(IAttributeDefinition attribdef, Order order)
		{
			Remove(attribdef);
			_terms.Insert(0,new Term(attribdef, order));
		}
		
		public void MinorSort(IAttributeDefinition attribdef, Order order)
		{
			Remove(attribdef);
			_terms.Add(new Term(attribdef, order));
		}

		private int IndexOf(IAttributeDefinition attribdef)
		{
			for (int i=0;i<_terms.Count;i++)
				if (_terms[i].AttributeDefinition == attribdef)
					return i;
			return -1;
		}

		private void Remove(IAttributeDefinition attribdef)
		{
			int index = IndexOf(attribdef);
			if (index == -1)
				return;
			_terms.RemoveAt(index);
		}

		public int Count { get { return _terms.Count; } }

		public string Token { get { return TextBuilder.Join(_terms,","); } }

		public override string ToString() { return Token; }

		public class Term
		{
			public readonly IAttributeDefinition AttributeDefinition;
			public readonly Order Order;

			public Term(IAttributeDefinition attribdef, Order order)
			{
				AttributeDefinition = attribdef;
				Order = order;
			}

			public string Token
			{
				get
				{
					string token = null;
					if (Order == Order.Ascending)
						token += "";
					else
						token += "-";
					token += AttributeDefinition.Token;
					return token;
				}
			}

			public override string ToString() { return Token; }
		}
	}
}
