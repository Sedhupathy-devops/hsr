package com.emids.da.repository;

import com.emids.da.model.KpiTracker;
import com.emids.da.repository.AbstractRepository;
import com.google.inject.persist.Transactional;

@Transactional
public class KpiRepository extends AbstractRepository<KpiTracker> {

  @Override
  public KpiTracker findById(Long id) {
    return find(KpiTracker.class, id);
  }
}
