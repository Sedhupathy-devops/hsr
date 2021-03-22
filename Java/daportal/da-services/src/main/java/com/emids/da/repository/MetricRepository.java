package com.emids.da.repository;

import com.emids.da.model.Metric;
import com.emids.da.repository.AbstractRepository;
import com.google.inject.persist.Transactional;

@Transactional
public class MetricRepository extends AbstractRepository<Metric> {

  @Override
  public Metric findById(Long id) {
    return find(Metric.class, id);
  }
}
