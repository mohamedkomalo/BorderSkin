using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using LayeredForms;
using LayeredForms.Utilities;

namespace BorderSkin.BorderSkinning.Skin
{
    internal enum SkinElementKeys
    {
        Frames,
        NormalTextBrush,
        MaxTextBrush,
        TextFormat,
        Font,
        StretchRect,
        ContentRect,
        NormalEdges,
        MaxEdges,
        BackColor,
        ElementAlign,
        TextAlign,
        ID,
        MaskOutBitmap,
        ImagePath
    }

    class SkinElement : IDisposable
    {
        public static readonly int MaskOutColor = 0xFFFFFF;
        
        private readonly Dictionary<SkinElementKeys, Object> _elements = new Dictionary<SkinElementKeys, object>();
        private bool _disposedValue;

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                foreach (object element in _elements.Values)
                {
                    var disposable = element as IDisposable;

                    if (disposable != null)
                    {
                        disposable.Dispose();
                    }
                }
            }
            _disposedValue = true;
        }
        public SolidBrush NormalTextBrush
        {
            get { return GetWithoutException<SolidBrush>(SkinElementKeys.NormalTextBrush); }
            set { _elements[SkinElementKeys.NormalTextBrush] = value; }
        }

        public SolidBrush MaxTextBrush
        {
            get { return GetWithoutException<SolidBrush>(SkinElementKeys.MaxTextBrush); }
            set { _elements[SkinElementKeys.MaxTextBrush] = value; }
        }

        public StringFormat TextFormat
        {
            get { return GetWithoutException<StringFormat>(SkinElementKeys.TextFormat); }
            set { _elements[SkinElementKeys.TextFormat] = value; }
        }

        public Font Font
        {
            get { return GetWithoutException<Font>(SkinElementKeys.Font); }
            set { _elements[SkinElementKeys.Font] = value; }
        }

        public Padding StretchPadding
        {
            get { return GetWithoutException<Padding>(SkinElementKeys.StretchRect); }
            set { _elements[SkinElementKeys.StretchRect] = value; }
        }

        public Padding ContentPadding
        {
            get { return GetWithoutException<Padding>(SkinElementKeys.ContentRect); }
            set { _elements[SkinElementKeys.ContentRect] = value; }
        }

        public Padding NormalEdges
        {
            get { return GetWithoutException<Padding>(SkinElementKeys.NormalEdges); }
            set { _elements[SkinElementKeys.NormalEdges] = value; }
        }

        public Padding MaxEdges
        {
            get { return GetWithoutException<Padding>(SkinElementKeys.MaxEdges); }
            set { _elements[SkinElementKeys.MaxEdges] = value; }
        }

        public Color BackColor
        {
            get { return GetWithoutException<Color>(SkinElementKeys.BackColor); }
            set { _elements[SkinElementKeys.BackColor] = value; }
        }

        public VerticalAlignment ElementAlign
        {
            get { return GetWithoutException<VerticalAlignment>(SkinElementKeys.ElementAlign); }
            set { _elements[SkinElementKeys.ElementAlign] = value; }
        }

        public VerticalAlignment TextAlign
        {
            get { return GetWithoutException<VerticalAlignment>(SkinElementKeys.TextAlign); }
            set { _elements[SkinElementKeys.TextAlign] = value; }
        }

        public String ID
        {
            get { return GetWithoutException<string>(SkinElementKeys.ID); }
            set { _elements[SkinElementKeys.ID] = value; }
        }

        public int FrameWidth
        {
            get { return FrameSize.Width; }
        }

        public int FrameHeight
        {
            get { return FrameSize.Height; }
        }

        public ImageWithDeviceContext MaskOutBitmap
        {
            get { return GetWithoutException<ImageWithDeviceContext>(SkinElementKeys.MaskOutBitmap); }
            set { _elements[SkinElementKeys.MaskOutBitmap] = value; }
        }

        public string ImagePath
        {
            get { return GetWithoutException<string>(SkinElementKeys.ImagePath); }
            set { _elements[SkinElementKeys.ImagePath] = value; }
        }

        public Size FrameSize
        {
            get { return Frames != null ? Frames[0].Size : Size.Empty; }
        }

        public ImageWithDeviceContext[] Frames
        {
            get { return GetWithoutException<ImageWithDeviceContext[]>(SkinElementKeys.Frames); }
            set { _elements[SkinElementKeys.Frames] = value; }
        }

        private T GetWithoutException<T>(SkinElementKeys property)
        {
            Object value;
            _elements.TryGetValue(property, out value);

            return value != null ? (T) value : default(T);
        }

        public SolidBrush GetTextBrush(bool maximized)
        {
            return maximized ? MaxTextBrush : NormalTextBrush;
        }

        public Padding GetEdges(bool maximized)
        {
            return maximized ? MaxEdges : NormalEdges;
        }

        public int GetStateYPosition(bool activeType)
        {
            return activeType ? 0 : FrameHeight;
        }

        public Padding CalculateEdgesRelativeToTopLeftCorner(int blockWidth, bool maximized)
        {
            return CalculateEdgesRelativeToTopLeftCorner(blockWidth, maximized, FrameWidth);
        }

        public Padding CalculateEdgesRelativeToTopLeftCorner(int blockWidth, bool maximized, int objectWidth)
        {
            Padding edges = GetEdges(maximized);

            switch (ElementAlign)
            {
                case VerticalAlignment.center:
                    edges.Left = (blockWidth/2) + (objectWidth/2) - (edges.Right + edges.Left);
                    break;
                case VerticalAlignment.right:
                    edges.Left = blockWidth - (objectWidth + edges.Left);
                    break;
            }

            return edges;
        }
    }
}