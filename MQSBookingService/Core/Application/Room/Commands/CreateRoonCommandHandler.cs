using Application.Room.DTO;
using Application.Room.Responses;
using Domain.DomainException;
using Domain.Ports;
using MediatR;

namespace Application.Room.Commands
{
    public class CreateRoomCommandHandler : IRequestHandler<CreateRoomCommand, RoomResponse>
    {
        public readonly IRoomRepository _RoomRepository;
        public CreateRoomCommandHandler(IRoomRepository RoomRepository)
        {
            _RoomRepository = RoomRepository;
        }
        public async Task<RoomResponse> Handle(CreateRoomCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var Room = RoomDTO.MapToEntity(request.RoomDTO);

                await Room.Save(_RoomRepository);
                request.RoomDTO.Id = Room.Id;

                return new RoomResponse
                {
                    Success = true,
                    Data = request.RoomDTO,
                };
            }
            catch (InvalidRoomPriceException)
            {
                return new RoomResponse
                {
                    Success = false,
                    ErrorCode = ErrorCodes.ROOM_MISSING_REQUIRED_INFORMATION,
                    Message = "Room price is invalid"
                };
            }
            catch (InvalidRoomDataException)
            {
                return new RoomResponse
                {
                    Success = false,
                    ErrorCode = ErrorCodes.ROOM_MISSING_REQUIRED_INFORMATION,
                    Message = "Missing required information passed"
                };
            }
            catch (Exception)
            {
                return new RoomResponse
                {
                    Success = false,
                    ErrorCode = ErrorCodes.ROOM_COULD_NOT_STORE_DATA,
                    Message = "There was an error when saving to DB"
                };
            }
        }
    }
}
