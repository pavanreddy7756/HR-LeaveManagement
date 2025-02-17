﻿using AutoMapper;
using HR.LeaveManagement.Application.Contracts.Logging;
using HR.LeaveManagement.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.Features.LeaveType.Queries.GetAllLeaveTypes
{
    public class GetLeaveTypesQueryHandler : IRequestHandler<GetLeaveTypesQuery, List<LeaveTypeDto>>
    {
        private readonly IMapper mapper;
        private readonly ILeaveTypeRepository leaveTypeRepository;
        private readonly IAppLogger<GetLeaveTypesQueryHandler> logger;

        public GetLeaveTypesQueryHandler(IMapper mapper,
                                         ILeaveTypeRepository leaveTypeRepository,
                                         IAppLogger<GetLeaveTypesQueryHandler> logger )
        {
            this.mapper = mapper;
            this.leaveTypeRepository = leaveTypeRepository;
            this.logger=logger;
        }


        public async Task<List<LeaveTypeDto>> Handle(GetLeaveTypesQuery request, CancellationToken cancellationToken)
        {
            //Query the database
            var leaveTypes = await leaveTypeRepository.GetAsync();

            //Convert data objects to DTO objects

            var data = mapper.Map < List<LeaveTypeDto>>(leaveTypes);

            //return list of DTO objects
            logger.LogInformation("Leave types were retreived successfully");

            return data;
        }
    }
}
