using System.Collections.Generic;
using System.Linq;

namespace VersionOne.SDK.APIClient {
    public abstract class GroupFilterTerm : IFilterTerm {
        private readonly IList<IFilterTerm> terms = new List<IFilterTerm>();

        public bool HasTerms {
            get { return terms.Count > 0; }
        }

        public string Token {
            get { return MakeToken(true); }
        }

        public string ShortToken {
            get { return MakeToken(false); }
        }

        private string MakeToken(bool full) {
            var tokens = terms.Select(term => full ? term.Token : term.ShortToken).Where(token => token != null).ToList();
            
            if(tokens.Count == 0) {
                return null;
            }
            
            if(tokens.Count == 1) {
                return tokens[0];
            }

            return "(" + string.Join(TokenSeperator, tokens.ToArray()) + ")";
        }

        protected abstract string TokenSeperator { get; }

        protected GroupFilterTerm(params IFilterTerm[] terms) {
            foreach(var term in terms.Where(term => term != null)) {
                this.terms.Add(term);
            }
        }

        public GroupFilterTerm And(params IFilterTerm[] terms) {
            var term = new AndFilterTerm(terms);
            this.terms.Add(term);
            return term;
        }

        public GroupFilterTerm Or(params IFilterTerm[] terms) {
            var term = new OrFilterTerm(terms);
            this.terms.Add(term);
            return term;
        }

        public FilterTerm Term(IAttributeDefinition def) {
            var term = new FilterTerm(def);
            terms.Add(term);
            return term;
        }
    }
}