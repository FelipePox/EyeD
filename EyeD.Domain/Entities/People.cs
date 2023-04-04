using EyeD.Domain.Core.Entities;
using EyeD.Domain.ValueObjects;

namespace EyeD.Domain.Entities
{
    public sealed class People : Entity
    {
        private People()
        { }

        public People(FullName name, FaceId faceId, ImageId imageId, ExternalImageId externalImageId, ReferenceDocument referenceDocument) : base()
        {
            Name = name;
            FaceId = faceId;
            ImageId = imageId;
            ExternalImageId = externalImageId;
            ReferenceDocument = referenceDocument;

            AddNotifications(Name, FaceId, ImageId, ExternalImageId, ReferenceDocument);
        }

        public FullName Name { get; private set; }
        public FaceId FaceId { get; private set; }
        public ImageId ImageId { get; private set; }
        public ExternalImageId ExternalImageId { get; private set; }
        public ReferenceDocument ReferenceDocument { get; private set; }


        public void Update(FullName name,
            FaceId faceId, 
            ImageId imageId, 
            ExternalImageId externalImageId,
            ReferenceDocument referenceDocument)
        {
            Name = name;
            FaceId = faceId;
            ImageId = imageId;
            ExternalImageId = externalImageId;
            ReferenceDocument = referenceDocument;

            AddNotifications(Name, FaceId, ImageId, ExternalImageId, ReferenceDocument);

            if (IsValid)
                AtualizadoEm = DateTime.Now.ToLocalTime();
        }


    }
}
