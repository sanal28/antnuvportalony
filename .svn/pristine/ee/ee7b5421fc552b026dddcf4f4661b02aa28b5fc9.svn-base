/****** Object:  View [dbo].[vueSharedType]    Script Date: 09/06/2017 05:54:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create view [dbo].[vueSharedType] 
as
select 1 as SharedTypeId,'All' as SharedTypeName
Union select 2 as SharedTypeId,'Managers' as SharedTypeName
Union select 3 as SharedTypeId,'Role' as SharedTypeName
Union select 4 as SharedTypeId,'Custom' as SharedTypeName
GO
ALTER TABLE [dbo].[tblAcademic] ADD  CONSTRAINT [DF__tblAcadem__Creat__5629CD9C]  DEFAULT ((0)) FOR [CreatedEmpID]
GO
ALTER TABLE [dbo].[tblAcademic] ADD  CONSTRAINT [DF__tblAcadem__Modif__571DF1D5]  DEFAULT ((0)) FOR [ModifiedEmpID]
GO
ALTER TABLE [dbo].[tblAllowance] ADD  CONSTRAINT [DF_tblAllowance_CreatedEmpID]  DEFAULT ((0)) FOR [CreatedEmpID]
GO
ALTER TABLE [dbo].[tblAllowance] ADD  CONSTRAINT [DF_tblAllowance_ModifiedEmpID]  DEFAULT ((0)) FOR [ModifiedEmpID]
GO
ALTER TABLE [dbo].[tblCategory] ADD  CONSTRAINT [DF_tblCategory_CreatedEmpID]  DEFAULT ((0)) FOR [CreatedEmpID]
GO
ALTER TABLE [dbo].[tblCategory] ADD  CONSTRAINT [DF_tblCategory_ModifiedEmpID]  DEFAULT ((0)) FOR [ModifiedEmpID]
GO
ALTER TABLE [dbo].[tblClientInfo] ADD  CONSTRAINT [DF_tblClientInfo_Status]  DEFAULT ((1)) FOR [Status]
GO
ALTER TABLE [dbo].[tblCompany] ADD  DEFAULT ((0)) FOR [CreatedEmpID]
GO
ALTER TABLE [dbo].[tblCompany] ADD  DEFAULT ((0)) FOR [ModifiedEmpID]
GO
ALTER TABLE [dbo].[tblCompetency] ADD  DEFAULT ((0)) FOR [CreatedEmpID]
GO
ALTER TABLE [dbo].[tblCompetency] ADD  DEFAULT ((0)) FOR [ModifiedEmpID]
GO
ALTER TABLE [dbo].[tblCountry] ADD  DEFAULT ((0)) FOR [CreatedEmpID]
GO
ALTER TABLE [dbo].[tblCountry] ADD  DEFAULT ((0)) FOR [ModifiedEmpID]
GO
ALTER TABLE [dbo].[tblEmployee] ADD  CONSTRAINT [DF__tblEmploy__Creat__52593CB8]  DEFAULT ((0)) FOR [CreatedEmpID]
GO
ALTER TABLE [dbo].[tblEmployee] ADD  CONSTRAINT [DF__tblEmploy__Modif__534D60F1]  DEFAULT ((0)) FOR [ModifiedEmpID]
GO
ALTER TABLE [dbo].[tblEmployeeAddress] ADD  CONSTRAINT [DF__tblEmploy__Creat__5441852A]  DEFAULT ((0)) FOR [CreatedEmpID]
GO
ALTER TABLE [dbo].[tblEmployeeAddress] ADD  CONSTRAINT [DF__tblEmploy__Modif__5535A963]  DEFAULT ((0)) FOR [ModifiedEmpID]
GO
ALTER TABLE [dbo].[tblEmpType] ADD  DEFAULT ((0)) FOR [CreatedEmpID]
GO
ALTER TABLE [dbo].[tblEmpType] ADD  DEFAULT ((0)) FOR [ModifiedEmpID]
GO
ALTER TABLE [dbo].[tblEmpTypeHierarchy] ADD  DEFAULT ((0)) FOR [CreatedEmpID]
GO
ALTER TABLE [dbo].[tblEmpTypeHierarchy] ADD  DEFAULT ((0)) FOR [ModifiedEmpID]
GO
ALTER TABLE [dbo].[tblExperience] ADD  CONSTRAINT [DF__tblExperi__Creat__59FA5E80]  DEFAULT ((0)) FOR [CreatedEmpID]
GO
ALTER TABLE [dbo].[tblExperience] ADD  CONSTRAINT [DF__tblExperi__Modif__5AEE82B9]  DEFAULT ((0)) FOR [ModifiedEmpID]
GO
ALTER TABLE [dbo].[tblIdentityDetails] ADD  CONSTRAINT [DF__tblIdenti__Creat__5BE2A6F2]  DEFAULT ((0)) FOR [CreatedEmpID]
GO
ALTER TABLE [dbo].[tblIdentityDetails] ADD  CONSTRAINT [DF__tblIdenti__Modif__5CD6CB2B]  DEFAULT ((0)) FOR [ModifiedEmpID]
GO
ALTER TABLE [dbo].[tblLeaveSettings] ADD  CONSTRAINT [DF_tblLeaveSettings_CanTakeAnyTime]  DEFAULT ((0)) FOR [CanTakeAnyTime]
GO
ALTER TABLE [dbo].[tblLeaveTransaction] ADD  CONSTRAINT [DF_tblLeaveTransaction_CreatedDate]  DEFAULT (getdate()) FOR [CreatedDate]
GO
ALTER TABLE [dbo].[tblLeaveTransaction] ADD  CONSTRAINT [DF_tblLeaveTransaction_ModifiedDate]  DEFAULT (getdate()) FOR [ModifiedDate]
GO
ALTER TABLE [dbo].[tblLeaveTransaction] ADD  CONSTRAINT [DF_tblLeaveTransaction_CreatedEmpID]  DEFAULT ((0)) FOR [CreatedEmpID]
GO
ALTER TABLE [dbo].[tblLeaveTransaction] ADD  CONSTRAINT [DF_tblLeaveTransaction_ModifiedEmpID]  DEFAULT ((0)) FOR [ModifiedEmpID]
GO
ALTER TABLE [dbo].[tblLeaveWFSettings] ADD  CONSTRAINT [DF_tblLeaveWFSettings_CreatedDate]  DEFAULT (getdate()) FOR [CreatedDate]
GO
ALTER TABLE [dbo].[tblLeaveWFSettings] ADD  CONSTRAINT [DF_tblLeaveWFSettings_ModifiedDate]  DEFAULT (getdate()) FOR [ModifiedDate]
GO
ALTER TABLE [dbo].[tblLeaveWFSettings] ADD  CONSTRAINT [DF_tblLeaveWFSettings_CreatedEmpID]  DEFAULT ((0)) FOR [CreatedEmpID]
GO
ALTER TABLE [dbo].[tblLeaveWFSettings] ADD  CONSTRAINT [DF_tblLeaveWFSettings_ModifiedEmpID]  DEFAULT ((0)) FOR [ModifiedEmpID]
GO
ALTER TABLE [dbo].[tblLogin] ADD  DEFAULT ((0)) FOR [CreatedEmpID]
GO
ALTER TABLE [dbo].[tblLogin] ADD  DEFAULT ((0)) FOR [ModifiedEmpID]
GO
ALTER TABLE [dbo].[tblReimbursement] ADD  CONSTRAINT [DF_tblReimbursement_CreatedEmpID]  DEFAULT ((0)) FOR [CreatedEmpID]
GO
ALTER TABLE [dbo].[tblReimbursement] ADD  CONSTRAINT [DF_tblReimbursement_ModifiedEmpID]  DEFAULT ((0)) FOR [ModifiedEmpID]
GO
ALTER TABLE [dbo].[tblRequests] ADD  CONSTRAINT [DF__tblReques__Creat__1E6F845E]  DEFAULT ((0)) FOR [CreatedEmpID]
GO
ALTER TABLE [dbo].[tblRequests] ADD  CONSTRAINT [DF__tblReques__Modif__1F63A897]  DEFAULT ((0)) FOR [ModifiedEmpID]
GO
ALTER TABLE [dbo].[tblRequestTypes] ADD  CONSTRAINT [DF__tblReques__Creat__2057CCD0]  DEFAULT ((0)) FOR [CreatedEmpID]
GO
ALTER TABLE [dbo].[tblRequestTypes] ADD  CONSTRAINT [DF__tblReques__Modif__214BF109]  DEFAULT ((0)) FOR [ModifiedEmpID]
GO
ALTER TABLE [dbo].[tblTicketStatus] ADD  CONSTRAINT [DF_tblRequestStatus_CreatedEmpID]  DEFAULT ((0)) FOR [CreatedEmpID]
GO
ALTER TABLE [dbo].[tblTicketStatus] ADD  CONSTRAINT [DF_tblRequestStatus_ModifiedEmpID]  DEFAULT ((0)) FOR [ModifiedEmpID]
GO
ALTER TABLE [dbo].[tblProjectDocument]  WITH CHECK ADD  CONSTRAINT [FK_tblProjectDocument_tblProjectDocument] FOREIGN KEY([DocumentId])
REFERENCES [dbo].[tblProjectDocument] ([DocumentId])
GO
ALTER TABLE [dbo].[tblProjectDocument] CHECK CONSTRAINT [FK_tblProjectDocument_tblProjectDocument]
GO