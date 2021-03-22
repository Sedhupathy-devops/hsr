package com.emids.da.repository;

import com.emids.da.model.DAActivity;
import com.emids.da.repository.AbstractRepository;
import com.google.inject.persist.Transactional;

@Transactional
public class DAActivityRepository extends AbstractRepository<DAActivity> {

  @Override
  public DAActivity findById(Long id) {
    return find(DAActivity.class, id);
  }
}
