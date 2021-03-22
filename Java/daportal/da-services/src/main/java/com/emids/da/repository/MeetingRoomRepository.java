package com.emids.da.repository;

import com.emids.da.model.MeetingRoom;
import com.emids.da.repository.AbstractRepository;
import com.google.inject.persist.Transactional;

@Transactional
public class MeetingRoomRepository extends AbstractRepository<MeetingRoom> {

  @Override
  public MeetingRoom findById(Long id) {
    return find(MeetingRoom.class, id);
  }
}
