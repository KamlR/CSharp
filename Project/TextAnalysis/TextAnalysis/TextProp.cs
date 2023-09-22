using System;
namespace TextAnalysis
{
	public struct TextProp
	{
		// Стартовый индекс анализируемого текста.
		public int start;
        // Конечный индекс анализируемого текста.
        public int end;
		// Текст для анализа.
		public string text_sub;
		public TextProp(int start, int end, string text_sub)
		{
			this.start = start;
			this.end = end;
			this.text_sub = text_sub;
		}
	}
}

