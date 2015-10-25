using System.Collections.Generic;
using System.Linq;

namespace Cradiator.Model
{
	public class BuildDataGrouper : IBuildDataTransformer
	{
		readonly IBuildDataTransformer _transformer;

		public BuildDataGrouper(IBuildDataTransformer transformer)
		{
			_transformer = transformer;
		}

		public IEnumerable<ProjectStatus> Transform(string xml)
		{
			return from status in _transformer.Transform(xml)
			       orderby status.CurrentState
			       select status;
		}
	}
}